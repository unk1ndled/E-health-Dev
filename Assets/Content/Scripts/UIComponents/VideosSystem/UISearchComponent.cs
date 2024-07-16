using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISearchComponent : UIAbstractComponent
{
    [SerializeField]
    private UISearchItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    public List<UISearchItem> listOfItems = new List<UISearchItem>();

    public event Action<int> OnItemClickRequested;


    public void InitializeComponentUI(int size)
    {
        for (int i = 0; i < size; i++)
        {
            UISearchItem item = Instantiate(itemPrefab, contentPanel);
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale = Vector3.one;
            listOfItems.Add(item);
            item.OnItemClicked += HandleItemClick;
        }
    }

    internal void ResetAllItems()
    {
        foreach (var item in listOfItems)
        {
            item.ResetData();
            item.Deselect();
        }
    }

    public void UpdateData(int itemIndex, string text)
    {
        if (listOfItems.Count > itemIndex)
        {
            listOfItems[itemIndex].SetData(text);
        }
    }

    private void HandleItemClick(UISearchItem item)
    {
        int index = listOfItems.IndexOf(item);
        if (index == -1)
        {
            return;
        }
        OnItemClickRequested?.Invoke(index);
    }

    public override void Show()
    {
        base.Show();
        gameObject.SetActive(true);
        ResetSelection();
    }

    public void ResetSelection()
    {
        foreach (UISearchItem item in listOfItems)
        {
            item.Deselect();
        }
    }

    public override void Hide()
    {
        base.Hide();
        gameObject.SetActive(false);

    }
}
