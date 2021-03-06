namespace Lerocia.Helpers {
  using System;
  using System.Collections.Generic;

  public class BiDictionary<TFirst, TSecond> {
    IDictionary<TFirst, TSecond> firstToSecond = new Dictionary<TFirst, TSecond>();
    IDictionary<TSecond, TFirst> secondToFirst = new Dictionary<TSecond, TFirst>();

    public void Add(TFirst first, TSecond second) {
      if (firstToSecond.ContainsKey(first) ||
          secondToFirst.ContainsKey(second)) {
        throw new ArgumentException("Duplicate first or second");
      }

      firstToSecond.Add(first, second);
      secondToFirst.Add(second, first);
    }

    public void RemoveByFirst(TFirst first) {
      TSecond second;
      firstToSecond.TryGetValue(first, out second);
      firstToSecond.Remove(first);
      secondToFirst.Remove(second);
    }

    public void RemoveBySecond(TSecond second) {
      TFirst first;
      secondToFirst.TryGetValue(second, out first);
      firstToSecond.Remove(first);
      secondToFirst.Remove(second);
    }

    public bool TryGetByFirst(TFirst first, out TSecond second) {
      return firstToSecond.TryGetValue(first, out second);
    }

    public bool TryGetBySecond(TSecond second, out TFirst first) {
      return secondToFirst.TryGetValue(second, out first);
    }
  }
}