using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegisterPanelManager : PanelManager {

    public GameObject PlaceableButtonPrefab;

    private Register.REGISTERS[] allowedRegisters;
    private GridLayoutGroup panel;

    new void Start()
    {
        base.Start();
        panel = GetComponentInChildren<GridLayoutGroup>();
        RefreshPanel();
    }

    public void SetAvailableRegisters(params Register.REGISTERS[] registers)
    {
        this.allowedRegisters = registers;
        if (panel != null)
        {
            RefreshPanel();
        }
    }

    public void RefreshPanel()
    {
        //Remove all old children
        PlaceableButton[] t = panel.gameObject.GetComponentsInChildren<PlaceableButton>();
        Debug.Log("Removing " + t.Length + " old registers.");
        for (int i = t.Length - 1; i >= 0; i--)
        {
            //Destroy the extras
            Destroy(t[i].gameObject);
        }

        //Create new children
        if (allowedRegisters == null)
        {
            return;
        }
        foreach (Register.REGISTERS reg in allowedRegisters)
        {
            GameObject g = Instantiate(PlaceableButtonPrefab) as GameObject;
            ((RectTransform)g.transform).SetParent(panel.transform);
            PlaceableButton p = g.GetComponent<PlaceableButton>();
            p.fillText = reg.ToString();
        }
    }
}
