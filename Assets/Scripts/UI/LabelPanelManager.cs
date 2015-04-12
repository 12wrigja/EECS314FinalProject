using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LabelPanelManager : PanelManager
{

    public GameObject PlaceableButtonPrefab;

    private string[] allowedLabels;
    private GridLayoutGroup panel;

    new void Start()
    {
        base.Start();
        panel = GetComponentInChildren<GridLayoutGroup>();
        RefreshPanel();
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
        }
    }
}