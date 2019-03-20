namespace Lerocia.Characters {
  using System.Collections.Generic;
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
    public Vector3 Origin;

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

    // Equipped armor & weapons
    public int WeaponId = -1;
    public int ApparelId = -1;

    public Dictionary<string, Dialogue> Dialogues;
    public int DialogueId;

    public InventoryBindingList Inventory;

    public Character() {
      IsLerpingPosition = false;
      IsLerpingRotation = false;
      Inventory = new InventoryBindingList();
      Inventory.AllowNew = true;
      Inventory.AllowRemove = true;
      Inventory.RaiseListChangedEvents = true;
      UpdateStats();
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
      Origin = avatar.transform.position;
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
      WeaponId = weaponId;
      ApparelId = apparelId;
      Inventory = new InventoryBindingList();
      Inventory.AllowNew = true;
      Inventory.AllowRemove = true;
      Inventory.RaiseListChangedEvents = true;
      DialogueId = dialogueId;
      Dialogues = DialogueList.Dialogues[dialogueId];
      UpdateStats();
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
      damage = damage - Armor;
      if (damage <= 0) {
        damage = 0;
      }

      CurrentHealth -= damage;
      if (CurrentHealth <= 0) {
        CurrentHealth = 0;
      }
    }
    
    public virtual string[] Interact(string prompt) {
      //TODO Handle character interaction
      return null;
    }

    public bool BuyItem(Character merchant, int itemId) {
      if (Gold >= ItemList.Items[itemId].GetValue() && merchant.Inventory.Contains(itemId)) {
        Gold -= ItemList.Items[itemId].GetValue();
        Inventory.Add(itemId);
        merchant.Inventory.Remove(itemId);
        merchant.Gold += ItemList.Items[itemId].GetValue();
        return true;
      }

      return false;
    }

    public void LootItem(Character body, int itemId) {
      Inventory.Add(itemId);
      body.Inventory.Remove(itemId);
    }

    public abstract void InitializeOnInventoryChange();

    protected abstract void OnInventoryChange(object sender, ListChangedEventArgs e);
  }
}