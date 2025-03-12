using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PlayItemType
{
    Rock,
    Paper,
    Scissor, 
    Lizard,
    Spock
}
public enum ItemRelationshipType
{
    Win,
    Lose,
    Draw
}
public class PlayItem : IComparable<PlayItem>
{
    public static GameRule GameRuleData { get; set; }
    protected List<PlayItemType> beatsOverItems;
    public PlayItemType type { get; private set; }
    public Sprite itemSprite { get; private set; }
   

    public PlayItem(PlayItemType type, Sprite _itemSprite )
    {
        this.type = type;
        this.itemSprite = _itemSprite;
        beatsOverItems = FetchBeatsOverTypes();
    }


    private List<PlayItemType> FetchBeatsOverTypes()
    {
        List<PlayItemType> beatTypes = new List<PlayItemType>();

        if (GameRuleData == null)
        {
            Debug.LogError("GameRuleData is not set in PlayItem!");
            return beatTypes;
        }

        // Find the rule matching this PlayItemType
        GameRule.Rule rule = GameRuleData.rules.Find(r => r.item == this.type);
        if (rule == null) return beatTypes;

        //Convert PlayItemType to actual class types
       
        return rule.beatsOver;
    }



    public ItemRelationshipType CompareTo(PlayItem other)
    {
        if (this.type == other.type) 
            return ItemRelationshipType.Draw;
        bool exist = beatsOverItems.Any<PlayItemType>(itemType => itemType == other.type);
        Debug.Log(" exist.. " + exist);
        Debug.Log("selfVictoryItems size: " + beatsOverItems.Count);
        foreach(PlayItemType t in beatsOverItems)
            Debug.Log(" items "+ t.ToString());
        
        return exist? ItemRelationshipType.Win : ItemRelationshipType.Lose;
    }
}
public class Rock : PlayItem
{
    public Rock(Sprite sprite) : base(PlayItemType.Rock, sprite) 
    { 
        //beatsOverItems = new List<Type> { typeof(Lizard), typeof(Scissor) }; 
    }
}
public class Paper : PlayItem
{
    public Paper(Sprite sprite) : base(PlayItemType.Paper, sprite) 
    { 
        //beatsOverItems = new List<Type> { typeof(Rock), typeof(Spock) }; 
    }
}
public class Scissor : PlayItem
{
    public Scissor(Sprite sprite) : base(PlayItemType.Scissor, sprite) 
    {
       // beatsOverItems = new List<Type> { typeof(Paper), typeof(Lizard) }; 
    } 
}
public class Lizard : PlayItem
{
    public Lizard(Sprite sprite) : base(PlayItemType.Lizard, sprite) 
    { 
       // beatsOverItems = new List<Type> { typeof(Paper), typeof(Spock) };
    }
}
public class Spock : PlayItem
{
    public Spock(Sprite sprite) : base(PlayItemType.Spock, sprite) 
    {
        //beatsOverItems = new List<Type> { typeof(Rock), typeof(Scissor) };
    }
}
