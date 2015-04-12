using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LabelPanelManager : PanelManager
{
    public GameObject PlaceableButtonPrefab;
    public Button panelHideButton;

    private delegate void HighlightAsLabelSlot(string label, Color highlightColor);
    private delegate void RemoveHighlighting(Color newColor);

    private HighlightAsLabelSlot registerSlotHighlighter;
    private RemoveHighlighting disableHighlighting;
    private Dictionary<Button, HighlightAsLabelSlot> buttonToDelegateMap;

    private string[] allowedLabels;
    private GridLayoutGroup panel;
    private static LabelPanelManager instance;
    new void Start()
    {
        base.Start();
        instance = this;
        buttonToDelegateMap = new Dictionary<Button, HighlightAsLabelSlot>();
        panel = GetComponentInChildren<GridLayoutGroup>();
        RefreshPanel();
        panelHideButton.onClick.AddListener(() => ClearLabelHighlighting());
    }

    public void SetAvailableLabels(params string[] labels)
    {
        this.allowedLabels = labels;
        if (panel != null)
        {
            RefreshPanel();
        }
    }

    public void RefreshPanel()
    {
        //Remove all old children
        PlaceableButton[] t = panel.gameObject.GetComponentsInChildren<PlaceableButton>();
        Debug.Log("Removing " + t.Length + " old labels.");
        for (int i = t.Length - 1; i >= 0; i--)
        {
            //Destroy the extras
            Destroy(t[i].gameObject);
        }

        //Create new children
        if (allowedLabels == null)
        {
            return;
        }
        foreach (string label in allowedLabels)
        {
            GameObject g = Instantiate(PlaceableButtonPrefab) as GameObject;
            ((RectTransform)g.transform).SetParent(panel.transform);
            PlaceableButton p = g.GetComponent<PlaceableButton>();
            p.fillText = label;
            SetupLabelHighlight(p.btn, label, Color.green);
        }
    }

    private void SetupLabelHighlight(Button btn, string label, Color highlightColor)
    {
        btn.onClick.AddListener(() => {
            registerSlotHighlighter(label, highlightColor);
            hidePanel();
        });
    }

    public static void RegisterAsLabelSlot(CodeLine line, Button labelSlot, Text labelText)
    {
        HighlightAsLabelSlot temp = (string label, Color c) =>
        {
            labelText.color = c;
            labelSlot.onClick.AddListener(() =>
            {
                line.SetLabel(label);
                LabelPanelManager.ClearLabelHighlighting();
            });
        };
        instance.buttonToDelegateMap.Add(labelSlot, temp);
        instance.registerSlotHighlighter += temp;
        instance.disableHighlighting += (Color n) =>
        {
            labelSlot.onClick.RemoveAllListeners();
            labelText.color = n;
        };
    }

    public static void DeregisterAsRegisterSlot(Button regSlot)
    {
        HighlightAsLabelSlot temp = instance.buttonToDelegateMap[regSlot];
        if (temp != null)
        {
            instance.registerSlotHighlighter -= temp;
        }
    }

    public static void ClearLabelHighlighting()
    {
        if (instance.disableHighlighting != null)
        {
            instance.disableHighlighting(Color.white);
        }
        
    }

}