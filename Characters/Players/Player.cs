namespace Lerocia.Characters.Players {
  using UnityEngine;
  using System.ComponentModel;

  public class Player : Character {
    public Player() { }

    public Player(
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
    ) { }

    public override void InitializeOnInventoryChange() {
      Debug.Log("Initialization of OnInventoryChange is not set up.");
    }

    protected override void OnInventoryChange(object sender, ListChangedEventArgs e) {
      Debug.Log("OnInventoryChange is not set up.");
    }
  }
}