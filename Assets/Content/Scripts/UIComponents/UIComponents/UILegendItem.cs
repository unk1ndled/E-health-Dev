using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILegendItem : UIAbstractComponent
{
    [SerializeField]
    private TextMeshProUGUI legendText;
    // Update is called once per frame
    public void SetLegendText(string text)
    {
        if ( legendText != null )
        {
            legendText.text = text;
        }
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }
}
