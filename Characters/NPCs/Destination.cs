namespace Lerocia.Characters.NPCs {
  using UnityEngine;

  public class Destination {
    public Vector3 Position;
    public int Duration;

    public Destination(Vector3 position, int duration) {
      Position = position;
      Duration = duration;
    }
  }
}