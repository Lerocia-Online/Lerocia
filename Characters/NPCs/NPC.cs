namespace Lerocia.Characters.NPCs {
  using UnityEngine;
  using System.ComponentModel;
  using System.Collections.Generic;

  public class NPC : Character {
    public Vector3 Origin;
    public List<Destination> Destinations;
    
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
      int dialogueId
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
      Origin = avatar.transform.position;
      Destinations = new List<Destination>();
    }

    public virtual string[] Interact(string prompt) {
      //TODO Handle NPC interaction
      return null;
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