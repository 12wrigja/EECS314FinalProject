using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RegisterPanelManager : PanelManager {

    public GameObject PlaceableButtonPrefab;

    private delegate void HighlightAsRegisterSlot(Register.REGISTERS regVal, Color highlightColor);
    private delegate void RemoveHighlighting(Color newColor);

    private HighlightAsRegisterSlot registerSlotHighlighter;
    private RemoveHighlighting disableHighlighting;
    private Dictionary<Button, HighlightAsRegisterSlot> buttonToDelegateMap;

    private Register.REGISTERS[] allowedRegisters;
    private GridLayoutGroup panel;

    private static RegisterPanelManager instance;

    new void Start()
    {
        base.Start();
        instance = this;
        panel = GetComponentInChildren<GridLayoutGroup>();
        RefreshPanel();
        buttonToDelegateMap = new Dictionary<Button, HighlightAsRegisterSlot>();
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
            SetupRegisterHighlight(p.btn, reg, Color.green);
        }
    }

    private void SetupRegisterHighlight(Button btn, Register.REGISTERS reg, Color highlightColor)
    {
        btn.onClick.AddListener(() => registerSlotHighlighter(reg, highlightColor));
    }

    public static void RegisterAsRegisterSlot(CodeLine line, Button regSlot, Text label, int operandNumber)
    {
        HighlightAsRegisterSlot temp = (Register.REGISTERS reg, Color c) =>
        {
            label.color = c;
            regSlot.onClick.AddListener(() =>
            {
                Register r = new Register(reg);
                switch (operandNumber)
                {
                    case 0:
                        line.setOperand1(r);
                        break;
                    case 1:
                        line.setOperand2(r);
                        break;
                    case 2:
                        line.setOperand3(r);
                        break;
                    default:
                        break;
                }
            });
        };
        instance.buttonToDelegateMap.Add(regSlot, temp);
        instance.registerSlotHighlighter += temp;
        instance.disableHighlighting += (Color n) =>
        {
            regSlot.onClick.RemoveAllListeners();
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

    public static void DeregisterAsRegisterSlot(Button regSlot)
    {
        if (!instance.buttonToDelegateMap.ContainsKey(regSlot))
        {
            return;
        }
        HighlightAsRegisterSlot temp = instance.buttonToDelegateMap[regSlot];
        if (temp != null)
        {
            instance.registerSlotHighlighter -= temp;
        }
    }
}
