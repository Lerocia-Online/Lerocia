namespace Lerocia.Characters.Bodies {
  using System.Collections.Generic;
  using UnityEngine;

  public class Body {
    public int BodyId;
    public string BodyName;
    public GameObject Avatar;
    public List<int> Inventory;

    public Body(int bodyId, string bodyName, GameObject avatar, List<int> inventory) {
      BodyId = bodyId;
      BodyName = bodyName;
      Avatar = avatar;
      Inventory = inventory;
    }
  }
}