using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVideoController : UIController
{
    [SerializeField]
    private UISearchComponent searchComponentUI;

    [SerializeField]
    private VideosInventorySO searchData;

    [SerializeField]
    private GameObject videoPlayer;

    #region Mock
    [SerializeField]
    private TextMeshProUGUI mocktext;
    #endregion

    public List<InventoryItem> initialItems = new List<InventoryItem>();


    private void Start()
    {
        PrepareUI();
        PrepareModel();
    }


    private void PrepareUI()
    {
        searchComponentUI.InitializeComponentUI(searchData.Size);
        searchComponentUI.OnItemClickRequested += HandleItemSelected;
    }

    private void PrepareModel()
    {
        searchData.Initialize();
        searchData.OnInventoryUpdated += UpdateInventoryUI;
        foreach (InventoryItem item in initialItems)
        {
            if (item.isEmpty)
            {
                continue;
            }
            searchData.AddItem(item);
        }
    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        searchComponentUI.ResetAllItems();
        foreach (var item in inventoryState)
        {
            searchComponentUI.UpdateData(item.Key, item.Value.itemSO.name);
        }
    }



    private void HandleItemSelected(int index)
    {
        InventoryItem inventoryItem = searchData.GetItemAt(index);
        if (inventoryItem.isEmpty)
        {
            return;
        }
        ShiftToVideoPlayer(inventoryItem);
        searchComponentUI.ResetSelection();
    }



    public override void Activate()
    {
        base.Activate();
        searchComponentUI.Show();
        foreach (var item in searchData.GetCurrentInventoryState())
        {
            searchComponentUI.UpdateData(item.Key, item.Value.itemSO.videoName);
        }

    }

    public override void Deactivate()
    {
        base.Deactivate();
        searchComponentUI.Hide();
    }

    private void ShiftToVideoPlayer(InventoryItem inventoryItem)
    {
        searchComponentUI.Hide();
        videoPlayer.SetActive(true);
        VideoItemSO inventoryData = inventoryItem.itemSO;
        mocktext.SetText(inventoryData.name);
        //TODOm inventoryItem => videoClip 
        //Get Component 
        // Fill Component video player with video clip THEN activate 
        // Undo 
    }

    public override void OnTransition()
    {

    }
}