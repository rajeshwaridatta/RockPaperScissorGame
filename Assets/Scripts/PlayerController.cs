using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayItem selectedItem;
    private Dictionary<string, PlayItem> itemDictionary;
    public static event Action<PlayItem> OnPlayerPlayedTurn;

    private void Start()
    {
        itemDictionary = new Dictionary<string, PlayItem>();
      
    }
    public void OnChooseSelection(string itemName )
    {
        List<PlayItem> items = GameManager.Instance.items;
        foreach (var item in items)
        {
            itemDictionary[item.type.ToString()] = item;

        }

        if (itemDictionary.TryGetValue(itemName, out PlayItem _selectedItem))
        {
            selectedItem = _selectedItem;
            OnPlayerPlayedTurn?.Invoke(this.selectedItem);
        }
        else
        {
            Debug.LogError($"Item {itemName} not found in dictionary!");
        }
    }
}
