using UnityEngine;

namespace Lerocia.Characters.Bodies {
  public class Body {
    public int BodyId;
    public int BodyName;
    public GameObject Avatar;

    public Body(int bodyId, int bodyName, GameObject avatar) {
      BodyId = bodyId;
      BodyName = bodyName;
      Avatar = avatar;
    }
  }
}