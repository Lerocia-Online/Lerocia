namespace Lerocia.Characters.NPCs {
  using UnityEngine;
  using System.ComponentModel;

  public class NPC : Character {
    public NPC() { }

    public NPC(
      int characterId, 
      string name, 
      GameObject avatar, 
      string characterPersonality, 
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
      name, 
      avatar, 
      characterPersonality, 
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
    ) { }

    public virtual string[] Interact(string prompt) {
      //TODO Handle NPC interaction
      return null;
    }

    protected override void Kill() {
      //TODO Handle NPC death
      IsDead = true;
      Dialogues = DialogueList.Dialogues[0];
    }

    public virtual void StartMerchant() {
      //TODO Handle NPC start merchant
    }

    public virtual void LootBody() {
      //TODO Handle NPC loot body
    }

    public override void InitializeOnInventoryChange() {
      Debug.Log("Initialization of OnInventoryChange is not set up.");
    }

    protected override void OnInventoryChange(object sender, ListChangedEventArgs e) {
      Debug.Log("OnInventoryChange is not set up.");
    }
  }
}