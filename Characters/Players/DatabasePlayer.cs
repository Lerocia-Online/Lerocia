namespace Lerocia.Characters.Players {
  using System;

  [Serializable]
  public class DatabasePlayer {
    public bool success;
    public string error;
    public int character_id;
    public string character_name;
  }
}