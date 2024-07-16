using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendContainer : MonoBehaviour
{
    [SerializeField]
    private Transform legendContainerTransform;

    private List<UILegendItem> legendItems = new List<UILegendItem>();

    private void Awake()
    {
        /*
        foreach(Transform child in legendContainerTransform)
        {
            UILegendItem legendItem = child.GetComponent<UILegendItem>();
            if ( legendItem != null )
            {
                legendItems.Add(legendItem);
            }
        } 
        */
    }

    public void ShowLegendItems(List<GameObject> targets)
    {
        for (int i = 0; i < legendItems.Count; i++)
        {
            UILegendItem legendItem = legendItems[i];
            legendItem.gameObject.transform.position = targets[i].transform.position;
            legendItem.gameObject.SetActive(true);
        }
    }

    public void HideLegendItems()
    {
        foreach (UILegendItem legendItem in legendItems)
        {
            legendItem.gameObject.SetActive(false);
        }
    }
}
