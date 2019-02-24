using System;

namespace Lerocia.Characters.Players {
  [Serializable]
  public class User {
    public bool success;
    public string error;
    public string username;
    public int user_id;
    public int connection_id;
  }
}