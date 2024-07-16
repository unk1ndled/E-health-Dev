using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDescriptionComponent : UIAbstractComponent
{
    #region data variables

    [SerializeField] private Text titleText;
    [SerializeField] private Text descriptionText;

    [SerializeField] private RectTransform descriptionContainer;
    [SerializeField] private float scrollSpeed = 20f;

    public event Action OnDescriptionRequested;

    private Coroutine autoScrollCoroutine;



    public void ResetDescription()
    {
        titleText.text = string.Empty;
        descriptionText.text = string.Empty;
    }

    public void SetDescription(string title, string description)
    {
        titleText.text = title;
        descriptionText.text = description;
    }

    #endregion

    #region Events

    public void Awake()
    {
        ResetDescription();
    }

    #endregion

    #region Auto-Display Methods

    public void StartAutoDisplay(float duration)
    {
        if (autoScrollCoroutine != null)
        {
            StopCoroutine(autoScrollCoroutine);
        }
        autoScrollCoroutine = StartCoroutine(AutoScrollCoroutine(duration));
    }

    private IEnumerator AutoScrollCoroutine(float duration)
    {
        float elapsedTime = 0f;
        float startY = descriptionText.rectTransform.anchoredPosition.y;
        float endY = -descriptionText.rectTransform.sizeDelta.y + descriptionContainer.sizeDelta.y;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newY = Mathf.Lerp(startY, endY, elapsedTime / duration);
            descriptionText.rectTransform.anchoredPosition = new Vector2(descriptionText.rectTransform.anchoredPosition.x, newY);
            yield return null;
        }

        descriptionText.rectTransform.anchoredPosition = new Vector2(descriptionText.rectTransform.anchoredPosition.x, endY);

    }

    public void StopAutoDisplay()
    {
        if (autoScrollCoroutine != null)
        {
            StopCoroutine(autoScrollCoroutine);
            autoScrollCoroutine = null;
        }
    }

    public void UpdateDescription()
    {
        OnDescriptionRequested?.Invoke();
    }

    public override void Hide()
    {
        base.Hide();
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        gameObject.SetActive(true);
    }

    #endregion
}
