# The Purifiers

## Overview

The Purifiers are a dedicated enemy faction designed specifically to oppose Sightstealer colonies.

They are a technologically advanced, spacefaring human faction whose doctrine is simple: anomalous life and the Rift must be destroyed by fire.

The Purifiers should become one of the principal ways The Dark One's Visibility system turns against the player. As Visibility increases, the Purifiers can become more frequent, better equipped, and increasingly specialised in fighting Sightstealers.

They should not feel like primitive fire-worshippers. They have **space-level technology** and deliberately apply advanced equipment to an anti-anomaly doctrine.

---

# Identity

**Faction:** The Purifiers

**Role:** High-tech anti-Sightstealer enemy faction

**Core doctrine:** Burn out the anomaly before it spreads.

**Technology level:** Spacer / spacefaring

**Primary combat philosophy:** Fire, heat, area denial, and light.

Their forces should understand that Sightstealers thrive in darkness. Their answer is not simply to bring stronger guns. It is to turn the battlefield into a brightly lit inferno.

---

# Appearance

The Purifiers use armour derived from the same general technological family as Imperial equipment, but their equipment is visually distinct.

### Armour

Their powered armour and related protective equipment should use the Empire's existing armour designs as the visual/technical base where appropriate, but be coloured **golden**.

The intended visual impression is:

- polished or slightly battle-worn gold armour
- advanced Imperial-style silhouettes
- bright metallic surfaces
- gold helmets and protective plating
- clean, imposing military presentation

They should look like an advanced military organisation, not a tribal cult.

If reusing vanilla equipment graphics, use colour channels/tints where the game supports them rather than duplicating assets unnecessarily.

---

# Weapons

Fire is the defining weapon category.

Primary weapons should include weapons such as:

- Hellcat Rifles
- Flamethrowers
- Incendiary weapons
- Other high-tech fire-based weapons where appropriate

The faction should also have conventional advanced weapons so that it remains a credible space-level military force, but fire weapons should be disproportionately common compared with ordinary factions.

### Tactical equipment

Higher-tier Purifier forces may use:

- incendiary grenades
- fire-based launchers
- portable light sources
- flares
- floodlights
- other equipment designed to deny darkness

The exact equipment pool should scale with faction strength and Visibility rather than giving every Purifier pawn every countermeasure immediately.

---

# Battlefield Doctrine

The Purifiers should behave as though they know what Sightstealers are.

Their preferred tactics are:

1. Illuminate dark areas.
2. Set vegetation and structures on fire where useful.
3. Deny safe darkness.
4. Force Sightstealers into the open.
5. Use fire to control movement.
6. Follow with conventional high-tech firepower.

This makes them a direct mechanical counter to the Sightstealer colony rather than merely another high-tech raid faction.

---

# Relationship With Visibility

The Purifiers are strongly connected to The Dark One's Visibility system.

At low Visibility they may not appear at all, or may appear only rarely.

As the colony becomes increasingly exposed, the Purifiers should become more likely to investigate or attack.

Suggested progression:

### Unseen / Rumoured

- Purifiers generally unaware of the colony.
- No dedicated Purifier pressure required.

### Suspected

- Occasional Purifier presence.
- Smaller reconnaissance forces.
- Some fire weapons.
- Basic anti-darkness equipment.

### Hunted

- Regular Purifier attacks become possible.
- Larger forces.
- Better armour.
- More incendiary weapons.
- More light-producing equipment.

### Exposed

- Purifier attacks can become major threats.
- Elite golden-armoured soldiers.
- Heavy firepower.
- Extensive fire and illumination equipment.
- Potentially specialised anti-Sightstealer units.

The Purifiers should therefore be one of the clearest manifestations of the Visibility feedback loop.

---

# Specialisation

Later development can introduce specialised Purifier units.

Possible roles:

### Purifier Infantry

Standard high-tech soldiers with a mixture of conventional and incendiary weapons.

### Flame Troopers

Close-range specialists carrying flamethrowers and other fire weapons.

### Lightbearers

Units carrying powerful portable illumination equipment whose primary role is denying darkness.

### Exterminators

Elite golden-armoured troops equipped specifically for destroying anomalous creatures and structures.

### Purifier Heavy Weapons

Advanced incendiary or area-denial weapons capable of setting large areas alight.

These are suggestions for future expansion and should not all be required for the first implementation.

---

# Faction Personality

The Purifiers should be hostile to the Sightstealer colony but not cartoonishly stupid.

They should understand that the anomaly is dangerous and genuinely believe that destroying it is necessary.

Their dialogue and event text should communicate:

- certainty
- military discipline
- fear of anomalous spread
- disgust toward the Rift
- determination to contain or destroy it

They should feel like an organisation that has fought anomalous outbreaks before.

---

# Interaction With The Rift

The Purifiers should particularly dislike Rift settlements and Rift structures.

Potential future behaviours/events include:

- attempting to burn Rift vegetation
- targeting Rift buildings
- setting fire to external crop areas
- attacking the Rift Gate during the endgame defence
- attempting to destroy or damage important Rift structures

The Purifiers should become especially dangerous during the final Rift Gate defence because their preferred weaponry naturally attacks the colony's greatest weakness: darkness and flammable materials.

---

# Design Principle

The Purifiers exist to create a specific strategic problem:

> **The darker your colony becomes, the more dangerous it is to outsiders. The more visible you become, the more prepared the outsiders become to bring the light to you.**

They should make the player think about defensive design, fire safety, alternative materials, battlefield darkness, and Visibility rather than simply increasing enemy hit points.

---

# Implementation Notes

Prefer existing RimWorld faction, PawnKind, equipment, apparel, and weapon systems wherever possible.

The faction should be implemented as a proper faction with its own `FactionDef`, `PawnKindDef`s, equipment generation rules, and appropriate hostile relationship to the Sightstealer colony.

Use existing Empire equipment as a reference/base where the game allows it, with golden colouring for Purifier armour. Do not duplicate assets unnecessarily.

Custom C# should only be used when required for unique Purifier behaviour or direct integration with Visibility.

The Purifiers are a future-facing design target. A minimal initial version can begin with a single high-tech PawnKind pool containing a strong proportion of fire weapons and golden armour, then expand into specialised units later.
