using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMemo : UIAbstractComponent
{
    [SerializeField]
    private TextMeshProUGUI memoText;

    private bool isEditable = true;
    // Start is called before the first frame update

    public void Initialize(string text, bool editable)
    {
        memoText.text = text;
        isEditable = editable;
        SetEditMode(editable);
    }

    private void SetEditMode(bool editable)
    {
        memoText.gameObject.SetActive(editable);
        
    }

    private void DeleteMemo()
    {
        Destroy(gameObject);
    }

    public void SetText(string text)
    {
        if ( isEditable)
        {
            memoText.text = text;
        }
    }

    public string GetText()
    {
        return memoText.text;
    }

    public bool IsEditable()
    {
        return isEditable;
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
