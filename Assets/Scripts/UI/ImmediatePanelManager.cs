using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImmediatePanelManager : PanelManager
{

    public GameObject PlaceableButtonPrefab;

    private string[] allowedImmediateValues;
    private GridLayoutGroup panel;

    new void Start()
    {
        base.Start();
        panel = GetComponentInChildren<GridLayoutGroup>();
        RefreshPanel();
    }

    public void SetAvailableImmediates(params string[] immediates)
    {
        this.allowedImmediateValues = immediates;
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
        if (allowedImmediateValues == null)
        {
            return;
        }
        foreach (string immediate in allowedImmediateValues)
        {
            GameObject g = Instantiate(PlaceableButtonPrefab) as GameObject;
            ((RectTransform)g.transform).SetParent(panel.transform);
            PlaceableButton p = g.GetComponent<PlaceableButton>();
            p.fillText = immediate;
        }
    }
}