namespace Lerocia.Characters.NPCs {
  using UnityEngine;
  using System.ComponentModel;
  using System.Collections.Generic;

  public class NPC : Character {
    public List<Destination> Destinations;
    public float RespawnTime;
    public float LookRadius;

    public NPC() { }

    public NPC(
      int characterId,
      string characterName,
      string characterPersonality,
      GameObject avatar,
      int maxHealth,
      int currentHealth,
      int maxStamina,
      int currentStamina,
      int gold,
      int baseWeight,
      int baseDamage,
      int baseArmor,
      int weaponId,
      int apparelId,
      int dialogueId,
      float respawnTime,
      float lookRadius,
      Vector3 origin
    ) : base(
      characterId,
      characterName,
      characterPersonality,
      avatar,
      maxHealth,
      currentHealth,
      maxStamina,
      currentStamina,
      gold,
      baseWeight,
      baseDamage,
      baseArmor,
      weaponId,
      apparelId,
      dialogueId,
      origin
    ) {
      Destinations = new List<Destination>();
      RespawnTime = respawnTime;
      LookRadius = lookRadius;
    }

    public virtual void StartMerchant() {
      //TODO Handle NPC start merchant
    }

    public override void InitializeOnInventoryChange() {
      Debug.Log("Initialization of OnInventoryChange is not set up.");
    }

    protected override void OnInventoryChange(object sender, ListChangedEventArgs e) {
      Debug.Log("OnInventoryChange is not set up.");
    }
  }
}