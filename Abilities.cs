using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace SightstealerColony
{
    public class CompProperties_InhumanScreech : CompProperties_AbilityEffect
    {
        public float radius = 10f;
        public float psychicComaChance = 0.1f;

        public CompProperties_InhumanScreech()
        {
            compClass = typeof(CompAbilityEffect_InhumanScreech);
        }
    }

    public class CompAbilityEffect_InhumanScreech : CompAbilityEffect
    {
        public new CompProperties_InhumanScreech Props
        {
            get { return (CompProperties_InhumanScreech)props; }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);

            Pawn caster = parent.pawn;
            if (caster == null || caster.Map == null)
            {
                return;
            }

            float radiusSquared = Props.radius * Props.radius;
            foreach (Pawn victim in caster.Map.mapPawns.AllPawnsSpawned.ToList())
            {
                if (victim == caster || victim.Dead || !victim.Spawned || SightstealerUtility.IsSightstealer(victim))
                {
                    continue;
                }

                if (caster.Position.DistanceToSquared(victim.Position) > radiusSquared)
                {
                    continue;
                }

                if (Rand.Chance(Props.psychicComaChance))
                {
                    SightstealerUtility.AddHediff(victim, "PsychicComa");
                }
                else if (victim.mindState != null)
                {
                    victim.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.PanicFlee);
                }
            }
        }
    }

    public class CompProperties_Sacrifice : CompProperties_AbilityEffect
    {
        public float ritualSpotRadius = 4.9f;

        public CompProperties_Sacrifice()
        {
            compClass = typeof(CompAbilityEffect_Sacrifice);
        }
    }

    public class CompAbilityEffect_Sacrifice : CompAbilityEffect
    {
        public new CompProperties_Sacrifice Props
        {
            get { return (CompProperties_Sacrifice)props; }
        }

        public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
        {
            return IsValidVictim(target) && HasRitualSpot(target.Pawn);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            if (!IsValidVictim(target))
            {
                return false;
            }

            return HasRitualSpot(target.Pawn);
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Messages.Message("The Veiled Offering must be performed as a psychic ritual at a ritual spot.", MessageTypeDefOf.RejectInput, false);
        }

        private bool IsValidVictim(LocalTargetInfo target)
        {
            Pawn victim = target.Pawn;
            return victim != null && victim.Spawned && !victim.Dead && (victim.IsPrisonerOfColony || victim.IsSlaveOfColony);
        }

        private bool HasRitualSpot(Pawn victim)
        {
            ThingDef spotDef = SightstealerUtility.GetDef<ThingDef>("PsychicRitualSpot");
            if (spotDef == null || victim == null || victim.Map == null)
            {
                return false;
            }

            foreach (IntVec3 cell in GenRadial.RadialCellsAround(victim.Position, Props.ritualSpotRadius, true))
            {
                if (cell.x < 0 || cell.z < 0 || cell.x >= victim.Map.Size.x || cell.z >= victim.Map.Size.z)
                {
                    continue;
                }

                foreach (Thing thing in victim.Map.thingGrid.ThingsListAtFast(cell))
                {
                    if (thing.def == spotDef)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private Pawn GenerateReplacement(Pawn caster)
        {
            PawnKindDef kind = SightstealerUtility.GetDef<PawnKindDef>("SS_Colonist");
            XenotypeDef xenotype = SightstealerUtility.GetDef<XenotypeDef>("SS_Sightstealer");
            if (kind == null || xenotype == null)
            {
                return null;
            }

            PawnGenerationRequest request = default(PawnGenerationRequest);
            request.Context = PawnGenerationContext.NonPlayer;
            request.KindDef = kind;
            request.Faction = caster.Faction;
            request.Tile = caster.Tile;
            request.ForceGenerateNewPawn = true;
            request.FixedBiologicalAge = 0f;
            request.FixedChronologicalAge = 0f;
            request.ForcedXenotype = xenotype;
            request.CanGeneratePawnRelations = false;
            request.ColonistRelationChanceFactor = 0f;
            request.RelationWithExtraPawnChanceFactor = 0f;
            return PawnGenerator.GeneratePawn(request);
        }

        private void CopySkillsAndTraits(Pawn source, Pawn destination)
        {
            if (source.story != null && source.story.traits != null && destination.story != null && destination.story.traits != null)
            {
                foreach (Trait trait in destination.story.traits.allTraits.ToList())
                {
                    destination.story.traits.RemoveTrait(trait);
                }

                foreach (Trait trait in source.story.traits.allTraits)
                {
                    destination.story.traits.GainTrait(new Trait(trait.def, trait.Degree));
                }
            }

            if (source.skills == null || destination.skills == null)
            {
                return;
            }

            foreach (SkillRecord sourceSkill in source.skills.skills)
            {
                SkillRecord destinationSkill = destination.skills.GetSkill(sourceSkill.def);
                destinationSkill.Level = sourceSkill.Level;
                destinationSkill.xpSinceLastLevel = sourceSkill.xpSinceLastLevel;
                destinationSkill.passion = sourceSkill.passion;
            }
        }

        private IntVec3 FindSpawnCell(Pawn caster)
        {
            foreach (IntVec3 cell in GenRadial.RadialCellsAround(caster.Position, 2f, true))
            {
                if (cell.x < 0 || cell.z < 0 || cell.x >= caster.Map.Size.x || cell.z >= caster.Map.Size.z)
                {
                    continue;
                }

                bool hasPawn = false;
                foreach (Thing thing in caster.Map.thingGrid.ThingsListAtFast(cell))
                {
                    if (thing is Pawn)
                    {
                        hasPawn = true;
                        break;
                    }
                }

                if (cell.Walkable(caster.Map) && !hasPawn)
                {
                    return cell;
                }
            }

            return caster.Position;
        }
    }

    [StaticConstructorOnStartup]
    public static class SightstealerHarmony
    {
    static SightstealerHarmony()
    {
        Harmony harmony = new Harmony("spider.sightstealercolony");
        try
        {
                TryPatchFoodMethod(harmony, typeof(Thing), typeof(SightstealerFoodThingPatch));
                TryPatchFoodMethod(harmony, typeof(ThingDef), typeof(SightstealerFoodDefPatch));
                TryPatch(harmony, typeof(Thing), "Ingested", new[] { typeof(Pawn) }, typeof(SightstealerForcedFoodPatch));
        }
        catch (Exception ex)
        {
                Log.Error("[Sightstealer Colony] Harmony initialization failed; affected patches were skipped: " + ex);
        }
    }

    private static void TryPatchFoodMethod(Harmony harmony, Type foodType, Type patchType)
    {
        TryPatch(harmony, typeof(FoodUtility), "WillEat", new[] { typeof(Pawn), foodType, typeof(Pawn), typeof(bool), typeof(bool) }, patchType);
    }

    private static void TryPatch(Harmony harmony, Type targetType, string methodName, Type[] argumentTypes, Type patchType)
    {
        MethodInfo target = AccessTools.Method(targetType, methodName, argumentTypes);
        if (target == null)
        {
            Log.Error("[Sightstealer Colony] Skipping Harmony patch: missing target " + targetType.FullName + "." + methodName + ".");
            return;
        }

        MethodInfo postfix = AccessTools.Method(patchType, "Postfix");
        if (postfix == null)
        {
            Log.Error("[Sightstealer Colony] Skipping Harmony patch: missing postfix " + patchType.FullName + ".Postfix.");
            return;
        }

        harmony.Patch(target, null, new HarmonyMethod(postfix));
    }
}

public static class SightstealerFoodThingPatch
    {
        public static void Postfix(ref bool __result, Pawn p, Thing food)
        {
            if (SightstealerUtility.IsSightstealer(p))
            {
                __result = IsAllowedFood(food);
            }
        }

        public static bool IsAllowedFood(Thing food)
        {
            return food is Corpse || (food != null && food.def != null && food.def.defName == "Meat_Twisted");
        }
    }

public static class SightstealerFoodDefPatch
    {
        public static void Postfix(ref bool __result, Pawn p, ThingDef food)
        {
            if (SightstealerUtility.IsSightstealer(p))
            {
                __result = food != null && (food.defName == "Meat_Twisted" || food.defName == "Corpse");
            }
        }
    }

public static class SightstealerForcedFoodPatch
    {
        public static void Postfix(Thing __instance, Pawn ingester)
        {
            if (!SightstealerUtility.IsSightstealer(ingester))
            {
                return;
            }

            if (__instance is Corpse)
            {
                ThoughtDef thought = SightstealerUtility.GetDef<ThoughtDef>("SS_AteCorpse");
                if (thought != null)
                {
                    if (ingester.needs != null && ingester.needs.mood != null)
                    {
                        ingester.needs.mood.thoughts.memories.TryGainMemory(thought);
                    }
                }

                ThoughtDef bileThought = SightstealerUtility.GetDef<ThoughtDef>("SS_CorpseBile");
                if (bileThought != null && ingester.needs != null && ingester.needs.mood != null)
                {
                    ingester.needs.mood.thoughts.memories.TryGainMemory(bileThought);
                }

                return;
            }

            if ((__instance.def == null || __instance.def.defName != "Meat_Twisted") && ingester.jobs != null)
            {
                ingester.jobs.StartJob(JobMaker.MakeJob(JobDefOf.Vomit), JobCondition.InterruptForced, null, true);
            }
        }
    }
}
