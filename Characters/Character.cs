using System;
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
    public string CharacterName;
    public string CharacterPersonality;
    public GameObject Avatar;

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
    public int WeaponId;
    public int ApparelId;
    
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
    ) {
      CharacterId = characterId;
      CharacterName = characterName;
      CharacterPersonality = characterPersonality;
      Avatar = avatar;
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
      WeaponId = weaponId;
      ApparelId = apparelId;
      Inventory = new InventoryBindingList();
      Inventory.AllowNew = true;
      Inventory.AllowRemove = true;
      Inventory.RaiseListChangedEvents = true;
      DialogueId = dialogueId;
      Dialogues = DialogueList.Dialogues[dialogueId];
    }

    public void UpdateStats() {
      if (WeaponId >= 0) {
        BaseWeapon weapon = ItemList.Items[WeaponId] as BaseWeapon;
        Damage = weapon.GetDamage();
      } else {
        Damage = BaseDamage;
      }

      if (ApparelId >= 0) {
        BaseApparel apparel = ItemList.Items[ApparelId] as BaseApparel;
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

    public void BuyItem(int itemId) {
      if (Gold >= ItemList.Items[itemId].GetValue()) {
        Gold -= ItemList.Items[itemId].GetValue();
        Inventory.Add(itemId);
      }
    }

    public void SellItem(int itemId) {
      if (Inventory.Contains(itemId)) {
        Inventory.Remove(itemId);
        Gold += ItemList.Items[itemId].GetValue();
      }
    }

    protected abstract void Kill();

    public abstract void InitializeOnInventoryChange();

    protected abstract void OnInventoryChange(object sender, ListChangedEventArgs e);
  }
}