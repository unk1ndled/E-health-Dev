using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoManager : MonoBehaviour
{
    [SerializeField]
    private GameObject memoPrefab;

    [SerializeField]
    private Transform memoContainer;

    private List<UIMemo> memos = new List<UIMemo>();

    public void CreateMemo(string text, Vector3 position, bool editable)
    {
        GameObject memoObject = Instantiate(memoPrefab, position, Quaternion.identity, memoContainer);
        UIMemo memo = gameObject.GetComponent<UIMemo>();
        memo.Initialize(text, editable);
        memos.Add(memo);
    }

    public void DeleteAllMemos()
    {
        foreach ( UIMemo memo in memos )
        {
            Destroy(memo.gameObject);
        }
        memos.Clear();
    }

    public void DeleteMemo(UIMemo memo)
    {
        if ( memos.Contains(memo))
        {
            Destroy(memo.gameObject);
            memos.Remove(memo);
        }
    }
}
