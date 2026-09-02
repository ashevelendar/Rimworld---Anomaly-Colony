# Visibility and Favour System

## Purpose

The Sightstealer colony should have a persistent measure of how much the outside world knows about it.

This system is inspired at a high level by the idea of a persistent visibility/knowledge value used by other RimWorld mods. It must be implemented independently and must not copy another mod's code or assets.

## Visibility

Visibility represents the amount of knowledge, suspicion, fear, and evidence surrounding the colony.

Recommended internal range: **0-100**.

The value should be saved with the game and remain persistent across saves.

### Suggested Visibility Tiers

| Range | Internal state | General meaning |
|---|---|---|
| 0-10 | Unseen | Almost nobody knows anything unusual is happening. |
| 10-25 | Rumoured | Strange reports and rumours are beginning to circulate. |
| 25-50 | Suspected | Outsiders are beginning to associate unusual activity with the colony. |
| 50-75 | Hunted | The colony is becoming a known threat and responses become deliberate. |
| 75-100 | Exposed | The colony's nature is effectively known to hostile outsiders. |

These thresholds should be configurable rather than permanently hard-coded.

## Sources of Visibility

Visibility should come from multiple sources. Killing should be important, but it should not be the entire mechanic.

### Killing NPC Pawns

Kills of hostile or neutral NPC humanlikes should increase Visibility.

The increase should be weighted by significance rather than treating every pawn identically.

Potential significance factors:

- Combat capability.
- Relevant skills.
- Faction rank.
- Noble status.
- Leader status.
- Unique or important pawn status.
- Whether the pawn was part of a major raid or event.

A highly important pawn should create substantially more attention than an anonymous low-level raider.

### Witnesses

Witnesses should matter.

If hostile or neutral pawns survive an incident and escape the map, they can carry information about what happened back to their faction.

A useful design rule is:

> If nobody survives to tell the story, the outside world receives less information.

Therefore:

- Killing all witnesses can produce a smaller Visibility increase.
- Allowing witnesses to escape can produce a larger increase.
- The exact system should avoid requiring a complicated faction intelligence simulation.

### Player-Controlled Deaths

Deaths caused by the player should not be treated as external evidence in a way that creates nonsensical feedback.

The implementation should distinguish NPC deaths from normal player-colony losses.

### Animals

Animal kills should normally have little or no Visibility impact unless the animal is unusually important or the death is part of a significant event.

### Sacrifices

Psychic sacrifices should increase Visibility because they represent unmistakable anomalous activity.

Suggested approach:

- Ordinary prisoner sacrifice: moderate Visibility gain.
- Important/high-value prisoner: larger gain.
- Large or unusually powerful sacrifice: potentially substantial gain.

Sacrifices should also be one of the strongest sources of Favour.

### Anomalous Activity

Some major Anomaly events or unusual psychic activity can increase Visibility.

This should be selective. Every Anomaly event should not automatically generate a large amount of Visibility.

### Psychic Rituals

Psychic rituals should primarily generate Favour, but significant rituals can also add a small amount of Visibility.

The better the ritual, the more meaningful the reward and potential attention can become.

## Visibility Decay

Visibility should gradually decrease if the colony remains quiet.

This creates an important strategic choice:

- Continue killing and accept increasing attention.
- Stop drawing attention and allow the world to forget.

Decay should be slow enough that the player cannot completely reset Visibility after every dangerous event.

Suggested starting point for testing: a small amount of decay per day, with the exact rate configurable.

## Visibility Effects

Visibility should affect more than raid size.

### Anomaly Threats

Higher Visibility should increase the frequency and/or severity of selected Anomaly incidents.

The Dark One should be able to use Visibility to make Anomaly threats escalate before normal Monolith progression would normally produce that level of pressure.

### Raids

Higher Visibility can influence:

- Raid frequency.
- Raid threat points.
- Raider composition.
- Special attacks.
- Faction willingness to target the colony.

### Light Countermeasures

As Visibility increases, hostile factions should gradually learn that darkness is important to the colony.

Possible countermeasures include:

- Torches.
- Flares.
- Incendiaries.
- Floodlights.
- Light-emitting equipment.
- Other appropriate anti-Sightstealer tools.

This should be staged. A low-Visibility colony should not immediately face an army equipped specifically to counter darkness.

### Enemy Behaviour

At high Visibility, selected enemies can become more prepared for the Sightstealer colony's strengths.

This should remain within normal RimWorld combat systems where possible rather than creating a huge custom AI framework.

### Positive Events

Visibility should not directly determine all rewards. Favour is intended to handle most positive reinforcement.

However, high Visibility can unlock certain unusual events or special interactions that would not occur while the colony remains completely unknown.

## Favour

Favour represents The Dark One's interest and approval.

Recommended internal range: **0-100**, although the implementation may use another representation if technically cleaner.

Favour should initially be hidden from the player or communicated indirectly through storyteller events. A large UI system is not required for the first implementation.

### Suggested Favour Sources

- Killing hostile NPC pawns.
- Killing significant NPC pawns.
- Sacrificing prisoners.
- Performing psychic rituals.
- Completing especially successful rituals.
- Surviving dangerous Anomaly encounters.
- Other strongly Sightstealer-themed actions.

### Favour Rewards

Possible rewards include:

- Riftstone or other Rift materials.
- Umbral Shards.
- Shadow Resin.
- Twisted Fibre.
- Void Sap.
- Healing or regeneration effects.
- Temporary darkness-related buffs.
- Psychic benefits.
- Useful animals.
- Rare resources.
- Useful equipment.
- Special Anomaly opportunities.

Rewards should scale gradually and should not make ordinary resource acquisition irrelevant.

## The Intended Trade-Off

The system should create a deliberate tension:

**More violence -> more Visibility -> more danger**

while simultaneously:

**More violence -> more Favour -> better rewards**

The player should therefore be able to choose between:

- Staying hidden and safe.
- Becoming increasingly visible and powerful.
- Deliberately provoking The Dark One for rewards.
- Retreating into secrecy long enough for Visibility to fall again.

## Technical Direction

Prefer a persistent storyteller/game-level component or another save-safe component appropriate to RimWorld's architecture.

Keep the system lightweight. Avoid checking every pawn every tick.

Good candidates for event-driven updates include:

- Pawn death.
- Pawn escape.
- Ritual completion.
- Major Anomaly events.
- Relevant storyteller events.

Use periodic processing only where necessary, such as Visibility decay.

All major values should be configurable for balancing.
