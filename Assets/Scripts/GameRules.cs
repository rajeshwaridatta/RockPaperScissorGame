using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules 
{
    public List<PlayItem> items = new List<PlayItem>();
    public void AddItem(PlayItem item) => items.Add(item);
   
}
