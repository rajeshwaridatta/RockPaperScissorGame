using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameRule", menuName = "Game Rules")]
public class GameRule : ScriptableObject
{
    [System.Serializable]
    public class Rule
    {
        public PlayItemType item;        
        public List<PlayItemType> beatsOver;
    }
    public List<Rule> rules = new List<Rule>();
   

}

