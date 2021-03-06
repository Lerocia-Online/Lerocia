using Lerocia.Characters.Bodies;

namespace Lerocia.Characters {
  using System.Collections.Generic;
  using Players;
  using NPCs;
  using Helpers;

  public static class ConnectedCharacters {
    public static DatabasePlayer MyDatabasePlayer;
    public static Player MyPlayer;
    public static List<int> ConnectionIds = new List<int>();
    public static BiDictionary<int, int> IdMap = new BiDictionary<int, int>();
    public static Dictionary<int, Character> Characters = new Dictionary<int, Character>();
    public static Dictionary<int, Player> Players = new Dictionary<int, Player>();
    public static Dictionary<int, NPC> NPCs = new Dictionary<int, NPC>();
    public static Dictionary<int, Body> Bodies = new Dictionary<int, Body>();
  }
}
