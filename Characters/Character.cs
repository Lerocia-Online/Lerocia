using System.Collections.Generic;

namespace Lerocia.Characters {
  using UnityEngine;
  using Items;
  using Items.Weapons;
  using Items.Apparel;
  using System.ComponentModel;
  using Helpers;

  public abstract class Character {
    // Identifiers
    public int CharacterId;
    public string Name;
    public GameObject Avatar;
    public string CharacterPersonality;

    // Movement interpolation
    public bool IsLerpingPosition;
    public bool IsLerpingRotation;
    public Vector3 RealPosition;
    public Quaternion RealRotation;
    public Vector3 LastRealPosition;
    public Quaternion LastRealRotation;
    public float TimeStartedLerping;
    public float TimeToLerp;
    public float TimeBetweenMovementStart;
    public float TimeBetweenMovementEnd;
    public float MoveTime;

    // Stats
    public int MaxHealth;
    public int CurrentHealth;
    public int MaxStamina;
    public int CurrentStamina;
    public int Gold;
    public int BaseWeight;
    public int Weight;
    public int BaseDamage;
    public int Damage;
    public int BaseArmor;
    public int Armor;
    public bool IsDead;

    // Equipped armor & weapons
    public int Weapon;
    public int Apparel;
    
    public Dictionary<string, Dialogue> Dialogues;
    public int DialogueId;

    public InventoryBindingList Inventory;

    public Character() {
      Avatar = new GameObject();
      IsLerpingPosition = false;
      IsLerpingRotation = false;
      IsDead = false;
      Inventory = new InventoryBindingList();
      Inventory.AllowNew = true;
      Inventory.AllowRemove = true;
      Inventory.RaiseListChangedEvents = true;
    }

    public Character(
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
    ) {
      CharacterId = characterId;
      Name = name;
      Avatar = avatar;
      CharacterPersonality = characterPersonality;
      IsLerpingPosition = false;
      IsLerpingRotation = false;
      RealPosition = avatar.transform.position;
      RealRotation = avatar.transform.rotation;
      TimeBetweenMovementStart = Time.time;
      MaxHealth = maxHealth;
      CurrentHealth = currentHealth;
      MaxStamina = maxStamina;
      CurrentStamina = currentStamina;
      Gold = gold;
      BaseWeight = baseWeight;
      Weight = BaseWeight;
      BaseDamage = baseDamage;
      Damage = BaseDamage;
      BaseArmor = baseArmor;
      Armor = BaseArmor;
      IsDead = false;
      Weapon = weapon;
      Apparel = apparel;
      Inventory = new InventoryBindingList();
      Inventory.AllowNew = true;
      Inventory.AllowRemove = true;
      Inventory.RaiseListChangedEvents = true;
      DialogueId = dialogueId;
      Dialogues = DialogueList.Dialogues[dialogueId];
    }

    public void UpdateStats() {
      if (Weapon >= 0) {
        BaseWeapon weapon = ItemList.Items[Weapon] as BaseWeapon;
        Damage = weapon.GetDamage();
      } else {
        Damage = BaseDamage;
      }

      if (Apparel >= 0) {
        BaseApparel apparel = ItemList.Items[Apparel] as BaseApparel;
        Armor = apparel.GetArmor();
      } else {
        Armor = BaseArmor;
      }
    }

    public void TakeDamage(int damage) {
      if (!IsDead) {
        damage = damage - Armor;
        if (damage <= 0) {
          damage = 0;
        }

        CurrentHealth -= damage;
        if (CurrentHealth <= 0) {
          Kill();
        }
      }
    }

    protected abstract void Kill();

    public abstract void InitializeOnInventoryChange();

    protected abstract void OnInventoryChange(object sender, ListChangedEventArgs e);
  }
}