using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISearchItem : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Text itemText;

    public event Action<UISearchItem> OnItemClicked;

    private bool isEmpty = true;

    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        itemText.text = "";
        isEmpty = true;
    }

    public void Deselect()
    {
        //to fill later on 
    }

    public void Select()
    {
        //to fill later on 
    }

    public void SetData(string text)
    {
        itemText.text = text;
    }

    public void OnButtonClicked()
    {
        OnItemClicked?.Invoke(this);
    }
}
