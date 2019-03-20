namespace Lerocia.Characters.NPCs {
  using UnityEngine;
  using System.ComponentModel;
  using System.Collections.Generic;

  public class NPC : Character {
    public List<Destination> Destinations;
    public int RespawnTime;

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
      int respawnTime
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
      dialogueId
    ) {
      Destinations = new List<Destination>();
      RespawnTime = respawnTime;
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