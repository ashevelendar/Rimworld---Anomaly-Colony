# Umbral Research

## Overview

The Sightstealer colony should have its own research tab representing knowledge that normal human researchers would not possess or understand.

**Research tab:** Umbral

The tab should contain the technology required to turn a primitive Sightstealer nest into a mature Rift colony and eventually construct the Rift Gate.

The research progression should reinforce the colony's identity and unlock mechanics gradually rather than making every Rift feature available immediately.

---

# Research Philosophy

Umbral research is not conventional scientific advancement.

The colony is learning how to understand, manipulate, and eventually cross the boundary between ordinary reality and the Rift.

The progression should move through five broad stages:

1. Understanding the Rift
2. Living Darkness
3. Umbral Communion
4. Walking Between Shadows
5. The Truth Beneath

Each stage should feel meaningfully more anomalous than the previous one.

---

# Tier I - Understanding the Rift

The first stage establishes the basic material and biological infrastructure of a Sightstealer colony.

## Suggested Projects

### Rift Ecology

Unlocks understanding and cultivation of Rift plants.

May unlock:

- Gloomroot
- Umbral Reed
- Shadowcap
- Dread Bloom
- Bleakvine
- Rift Thorn
- other basic Rift flora

### Riftstone Working

Allows Riftstone to be mined and processed for construction.

Unlocks:

- Riftstone walls
- Riftstone doors
- Riftstone floors
- basic Riftstone furniture

### Umbral Materials

Introduces processing of:

- Shadow Resin
- Twisted Fibre
- basic Rift-derived materials

### Rift Sustenance

Improves the colony's ability to sustain Sightstealers through corpses, Twisted Meat, and Rift-derived resources.

Potential unlocks:

- improved corpse storage
- specialised corpse preservation
- Rift food-processing structures

---

# Tier II - Living Darkness

The second stage moves from surviving in the Rift to deliberately shaping the environment around the colony.

## Suggested Projects

### Living Architecture

Unlocks more advanced structures made from Rift-derived biological materials.

Potential unlocks:

- Umbral Hearth
- Rift Nest
- advanced Rift furniture
- organic decorative structures

### Shadow Manipulation

Unlocks structures capable of influencing local darkness.

Potential unlocks:

- Shadow Veil
- darkness-generating structures
- improved darkness control

### Rift Cultivation

Improves Rift plant cultivation and unlocks higher-value flora.

Potential unlocks:

- Hollowtree cultivation
- Void Sap production
- improved Shadow Resin production
- improved Twisted Fibre production

### Riftstone Reinforcement

Allows stronger forms of Riftstone construction.

Potential unlocks:

- reinforced Riftstone walls
- stronger doors
- advanced defensive structures

Riftstone remains vulnerable to fire even after reinforcement.

---

# Tier III - Umbral Communion

The third stage concerns psychic interaction with the Rift and the colony's religious practices.

## Suggested Projects

### Psychic Communion

Unlocks structures and technologies for deliberately interacting with psychic phenomena.

Potential unlocks:

- Psychic Resonator
- advanced psychic ritual infrastructure
- psychic-related consumables

### Sacrificial Architecture

Improves the colony's sacrificial rituals.

Potential unlocks:

- Rift Altar
- specialised sacrifice infrastructure
- improved ritual quality or reliability
- enhanced integration with Sightstealer reproduction

### Dread Bloom Cultivation

Unlocks reliable production of Dread Petals.

Dread Petals become a useful reagent for psychic rituals and other Umbral technologies.

### Void Sap Extraction

Unlocks dedicated extraction/processing of Void Sap from suitable Rift flora.

Potential uses:

- medicine
- psychic consumables
- advanced rituals
- later Umbral research

---

# Tier IV - Walking Between Shadows

The fourth stage represents mastery of movement through darkness and increasingly direct manipulation of space.

## Suggested Projects

### Shadow Step

Improves understanding of Sightstealer teleportation.

Potential unlocks:

- improved teleportation infrastructure
- teleportation-related buildings
- longer-range or more reliable teleportation where appropriate

### Shadow Gate

Unlocks a structure that allows controlled movement between linked points within the colony or map.

The exact mechanics should be determined during implementation and balanced around the existing Sightstealer teleport ability.

### Obscuring Obelisk

Creates an area designed to interfere with visibility and preserve darkness around important structures.

Potential uses:

- defensive darkness
- concealment
- protection of important Rift infrastructure

### Umbral Beacon

A high-tier structure capable of manipulating or concentrating Rift energy.

It may become a prerequisite for the final Rift Gate research.

---

# Tier V - The Truth Beneath

The final research stage concerns the boundary between the Rift and ordinary reality.

This tier should unlock the technology required to build the colony's unique victory structure.

## Suggested Projects

### Condensed Void

Unlocks the processing and controlled use of Condensed Void.

Condensed Void is an extremely rare and valuable end-game resource.

Potential uses:

- advanced Umbral structures
- Rift Gate components
- final-tier technology

### Dark Archeotech

Unlocks understanding of Dark Archeotech Shards recovered from anomalous creatures.

These shards are required for the Rift Gate and represent knowledge that cannot be obtained from ordinary research alone.

### Rift Boundary

The final conceptual research project.

Unlocks the ability to construct the Rift Gate.

This research should require substantial investment and should represent a major end-game milestone.

---

# Rift Gate Research

The final research should unlock the **Rift Gate**, the colony's unique victory structure.

The Rift Gate is based visually on a large Skipgate, but its appearance should be distinctly Umbral:

- black/dark construction
- anomalous distortion
- minimal or no conventional illumination
- visual similarity to a Skipgate while clearly belonging to the Sightstealer colony

The structure requires large quantities of Rift materials and Dark Archeotech Shards.

See `rift-gate-victory.md` for the complete victory condition and construction requirements.

---

# Suggested Research Order

```text
Understanding the Rift
    |
    +-- Rift Ecology
    +-- Riftstone Working
    +-- Umbral Materials
    +-- Rift Sustenance
    |
    v
Living Darkness
    |
    +-- Living Architecture
    +-- Shadow Manipulation
    +-- Rift Cultivation
    +-- Riftstone Reinforcement
    |
    v
Umbral Communion
    |
    +-- Psychic Communion
    +-- Sacrificial Architecture
    +-- Dread Bloom Cultivation
    +-- Void Sap Extraction
    |
    v
Walking Between Shadows
    |
    +-- Shadow Step
    +-- Shadow Gate
    +-- Obscuring Obelisk
    +-- Umbral Beacon
    |
    v
The Truth Beneath
    |
    +-- Condensed Void
    +-- Dark Archeotech
    +-- Rift Boundary
    |
    v
RIFT GATE
```

---

# Design Rules

### 1. Do not make every project mandatory

Where sensible, projects can branch. The player should have meaningful choices in which parts of the Umbral technology tree they prioritise.

### 2. Avoid unnecessary dependencies

The research system should primarily depend on the base game, Biotech, and Anomaly, matching the mod's intended dependency model.

### 3. Keep V1 achievable

The first implementation does not need every suggested project to have an elaborate custom mechanic. Some can initially unlock straightforward Defs, buildings, resources, or stat changes.

### 4. Research should tell a story

The names and descriptions should communicate a progression from:

**survival -> adaptation -> communion -> mastery -> transcendence**

### 5. The final research should feel dangerous

The player is not merely researching a better machine. They are learning how to tear open a controlled passage into the Rift.

That should feel like a major Anomaly milestone.
