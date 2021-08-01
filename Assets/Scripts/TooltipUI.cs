using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    [SerializeField] RectTransform background;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] GameObject TooltipText, tooltip;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] RectTransform canvasRectTransform;

    void Awake()
    {
        Instance = this;

        HideTooltip();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;

        rectTransform.anchoredPosition = anchoredPosition;
    }

    void SetText(string tooltipText)
    {
        textMeshPro.text = tooltipText;
        //textMeshPro.ForceMeshUpdate();

        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(8, 8);
        background.sizeDelta = textSize;
    }

    void ShowTooltip(string tooltipText)
    {
        tooltip.SetActive(true);
        SetText(tooltipText);
    }

    void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    public static void Show(string tooltipText)
    {
        Instance.ShowTooltip(tooltipText);
    }

    public static void Hide()
    {
        Instance.HideTooltip();
    }
}
