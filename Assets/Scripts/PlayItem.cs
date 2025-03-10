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
    protected List<Type> selfVictoryItems;
    public PlayItemType type { get; private set; }
    public Sprite itemSprite { get; private set; }
   

    public PlayItem(PlayItemType type, Sprite _itemSprite )
    {
        this.type = type;
        this.itemSprite = _itemSprite;
    }
   

    public ItemRelationshipType CompareTo(PlayItem other)
    {
        if (this.GetType() == other.GetType()) 
            return ItemRelationshipType.Draw;
        bool exist = selfVictoryItems.Any<Type>(itemType => itemType == other.GetType());
        Debug.Log(" exist.. " + exist);
        Debug.Log("selfVictoryItems size: " + selfVictoryItems.Count);
        foreach(Type t in selfVictoryItems)
            Debug.Log(" items "+ t.ToString());
        
        return exist? ItemRelationshipType.Win : ItemRelationshipType.Lose;
    }
}
public class Rock : PlayItem
{
    public Rock(Sprite sprite) : base(PlayItemType.Rock, sprite) 
    { 
        selfVictoryItems = new List<Type> { typeof(Lizard), typeof(Scissor) }; 
    }
}
public class Paper : PlayItem
{
    public Paper(Sprite sprite) : base(PlayItemType.Paper, sprite) 
    { 
        selfVictoryItems = new List<Type> { typeof(Rock), typeof(Spock) }; 
    }
}
public class Scissor : PlayItem
{
    public Scissor(Sprite sprite) : base(PlayItemType.Scissor, sprite) 
    {
        selfVictoryItems = new List<Type> { typeof(Paper), typeof(Lizard) }; 
    } 
}
public class Lizard : PlayItem
{
    public Lizard(Sprite sprite) : base(PlayItemType.Lizard, sprite) 
    { 
        selfVictoryItems = new List<Type> { typeof(Paper), typeof(Spock) };
    }
}
public class Spock : PlayItem
{
    public Spock(Sprite sprite) : base(PlayItemType.Spock, sprite) 
    {
        selfVictoryItems = new List<Type> { typeof(Rock), typeof(Scissor) };
    }
}
