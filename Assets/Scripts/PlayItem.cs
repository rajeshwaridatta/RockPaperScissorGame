using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayItemType
{
    Rock,
    Paper,
    Scissor
}
public enum ItemRelationshipType
{
    Pass,
    Fail,
    Draw
}
public class PlayItem : IComparable<PlayItem>
{
    public PlayItemType type { get; private set; }
    public Sprite itemSprite { get; private set; }
    private Dictionary<PlayItem, ItemRelationshipType> relationships = new Dictionary<PlayItem, ItemRelationshipType>();

    public PlayItem(PlayItemType type, Sprite _itemSprite )
    {
        this.type = type;
        this.itemSprite = _itemSprite;
    }
    public void AddBehaviour(PlayItem other, ItemRelationshipType relation)
    {
        relationships[other] = relation;
    }

    public ItemRelationshipType CompareTo(PlayItem other)
    {
        return relationships.ContainsKey(other)? relationships[other]: ItemRelationshipType.Draw;
    }
}
public class Rock : PlayItem
{
    public Rock(Sprite sprite) : base(PlayItemType.Rock, sprite) { }
}
public class Paper : PlayItem
{
    public Paper(Sprite sprite) : base(PlayItemType.Paper, sprite) { }
}
public class Scissor : PlayItem
{
    public Scissor(Sprite sprite) : base(PlayItemType.Scissor, sprite) { }
}
