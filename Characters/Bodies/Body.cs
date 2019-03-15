using UnityEngine;

namespace Lerocia.Characters.Bodies {
  public class Body {
    public int BodyId;
    public string BodyName;
    public GameObject Avatar;

    public Body(int bodyId, string bodyName, GameObject avatar) {
      BodyId = bodyId;
      BodyName = bodyName;
      Avatar = avatar;
    }
  }
}