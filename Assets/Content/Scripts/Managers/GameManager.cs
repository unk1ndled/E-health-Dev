using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    #region fields
    [SerializeField] List<GameObject> managerGameObjects;
    public bool isTesting = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartGameSesssion();
    }

    async void StartGameSesssion()
    {
        SetManagers(true);
        //InitiateGameIntroEffect();
        //await UniTask.Delay(4000);
    }

    void SetManagers(bool doActivate)
    {
        foreach (var gameObject in managerGameObjects)
        {
            gameObject.SetActive(doActivate);
        }
    }

    // Update is called once per frame
    /*
    async UniTask InitiateGameIntroEffect()
    {
        if (!isTesting)
        {
            GameScriptsFactory.Instance.guiManager.ToggleAppSplashScreen(12);

            await UniTask.Delay(18000);
        }

        SetManagers(true);
    }

    async UniTask LoadGameObjectsIntoMemory()
    {
        //FOR NOW NOTHING :)
    }
    #endregion
    */
}