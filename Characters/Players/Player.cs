namespace Lerocia.Characters.Players {
  using UnityEngine;
  using System.ComponentModel;

  public class Player : Character {
    public Player() { }

    public Player(
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
      int weapon, 
      int apparel, 
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
      weapon,
      apparel, 
      dialogueId
    ) { }

    protected override void Kill() {
      //TODO Handle Player death
      // Reset players health
      CurrentHealth = MaxHealth;
      // Move them back to "spawn" point
      Avatar.transform.position = new Vector3(0, 1, 0);
    }

    public override void InitializeOnInventoryChange() {
      Debug.Log("Initialization of OnInventoryChange is not set up.");
    }

    protected override void OnInventoryChange(object sender, ListChangedEventArgs e) {
      Debug.Log("OnInventoryChange is not set up.");
    }
  }
}