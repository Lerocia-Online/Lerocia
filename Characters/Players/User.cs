namespace Lerocia.Characters.Players {
  using System;

  [Serializable]
  public class User {
    public bool success;
    public string error;
    public int character_id;
    public string character_name;
    public int connection_id;
  }
}