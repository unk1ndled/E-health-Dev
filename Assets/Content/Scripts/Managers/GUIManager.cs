using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    #region references

    [SerializeField]
    private GameObject appLogoGameObject;

    public Transform userCamera;
    public float distanceInFront = 2.0f;
    public float height = 1.5f;
    [SerializeField] private float rotationSpeed = 2.5f;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (userCamera == null)
        {
            Debug.Log("The User Camera Is not assigned");
            return;
        }

        transform.position = userCamera.position + userCamera.forward * distanceInFront + new Vector3(0, height, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - userCamera.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    #region GUIEvents

    public void ToggleAppSplashScreen(float fadeInDuration)
    {
        appLogoGameObject.SetActive(true);
        appLogoGameObject.GetComponentInChildren<Image>().DOFade(1f, fadeInDuration)
            .OnComplete(() => OnComplete(fadeInDuration));
    }

    void OnComplete(float fadeInDuration)
    {
        appLogoGameObject.GetComponentInChildren<Image>().DOFade(0f, fadeInDuration / 2)
            .OnComplete(() => appLogoGameObject.SetActive(false));
    }
    #endregion
}
