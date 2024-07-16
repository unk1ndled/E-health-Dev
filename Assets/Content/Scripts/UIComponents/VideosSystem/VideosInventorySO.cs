using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class VideosInventorySO : ScriptableObject
{

    [SerializeField]
    private List<InventoryItem> inventoryItems;

    [field: SerializeField]
    public int Size { get; private set; } = 10;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    public void AddItem(VideoItemSO item)
    {

        if (IsInventoryFull() == false)
        {
            AddItemToFirstFreeSlot(item);
        }
        InformAboutChange();
    }

    private void AddItemToFirstFreeSlot(VideoItemSO itemSO)
    {
        InventoryItem newItem = new InventoryItem
        {
            itemSO = itemSO,
        };

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].isEmpty)
            {
                inventoryItems[i] = newItem;
                return;
            }
        }
        return;
    }

    private bool IsInventoryFull()
        => inventoryItems.Where(item => item.isEmpty).Any() == false;


    public void AddItem(InventoryItem item)
    {
        AddItem(item.itemSO);
    }

    public InventoryItem GetItemAt(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }


    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].isEmpty)
                continue;
            returnValue[i] = inventoryItems[i];
        }
        return returnValue;
    }

    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }


}

[Serializable]
public struct InventoryItem
{
    public VideoItemSO itemSO;
    public bool isEmpty => itemSO == null;

    public static InventoryItem GetEmptyItem() => new InventoryItem
    {
        itemSO = null,
    };
}
