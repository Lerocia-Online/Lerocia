namespace Lerocia.Characters.Players {
  using System;

  [Serializable]
  public class User {
    public bool success;
    public string error;
    public string character_id;
    public int character_name;
    public int connection_id;
  }
}