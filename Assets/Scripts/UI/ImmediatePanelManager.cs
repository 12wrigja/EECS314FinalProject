using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImmediatePanelManager : PanelManager
{

    public GameObject PlaceableButtonPrefab;

    private delegate void HighlightAsImmediateSlot(Immediate imm, Color highlightColor);
    private delegate void RemoveHighlighting(Color newColor);

    private HighlightAsImmediateSlot immediateSlotHighlighter;
    private RemoveHighlighting disableHighlighting;
    private Dictionary<Button, HighlightAsImmediateSlot> buttonToDelegateMap;

    private string[] allowedImmediateValues;
    private GridLayoutGroup panel;
    private static ImmediatePanelManager instance;

    new void Start()
    {
        base.Start();
        instance = this;
        panel = GetComponentInChildren<GridLayoutGroup>();
        buttonToDelegateMap = new Dictionary<Button, HighlightAsImmediateSlot>();
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
            SetupImmediateHighlight(p.btn, new Immediate(immediate),Color.green);
        }
    }

    private void SetupImmediateHighlight(Button btn, Immediate imm, Color highlightColor)
    {
        btn.onClick.AddListener(() => immediateSlotHighlighter(imm, highlightColor));
    }

    public static void RegisterAsRegisterSlot(CodeLine line, Button immSlot, Text label, int operandNumber)
    {
        HighlightAsImmediateSlot temp = (Immediate imm, Color c) =>
        {
            label.color = c;
            immSlot.onClick.AddListener(() =>
            {
                switch (operandNumber)
                {
                    case 0:
                        line.setOperand1(imm);
                        break;
                    case 1:
                        line.setOperand2(imm);
                        break;
                    case 2:
                        line.setOperand3(imm);
                        break;
                    default:
                        break;
                }
            });
        };
        instance.buttonToDelegateMap.Add(immSlot, temp);
        instance.immediateSlotHighlighter += temp;
        instance.disableHighlighting += (Color n) =>
        {
            immSlot.onClick.RemoveAllListeners();
            label.color = n;
        };
    }

    public override void hidePanel()
    {
        base.hidePanel();
        if (disableHighlighting != null)
        {
            disableHighlighting(Color.white);
        }

    }

    public static void DeregisterAsImmediateSlot(Button immSlot)
    {
        if (!instance.buttonToDelegateMap.ContainsKey(immSlot))
        {
            return;
        }
        HighlightAsImmediateSlot temp = instance.buttonToDelegateMap[immSlot];
        if (temp != null)
        {
            instance.immediateSlotHighlighter -= temp;
        }
    }
}