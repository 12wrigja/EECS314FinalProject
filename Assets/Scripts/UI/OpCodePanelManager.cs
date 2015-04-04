using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class OpCodePanelManager : PanelManager {

    public GameObject InstructionButtonPrefab;

    private Instruction.OPCODE[] allowedOpCodes;
    private GridLayoutGroup panel;

    void Start()
    {
        base.Start();
        panel = GetComponentInChildren<GridLayoutGroup>();
        Debug.Log(panel.name);
    }

    public void SetAvailableOpCodes(params Instruction.OPCODE[] codes)
    {
        this.allowedOpCodes = codes;
    }

    public void RefreshPanel()
    {
        //Remove all old children
        InstructionButton[] t = panel.gameObject.GetComponentsInChildren<InstructionButton>();
        Debug.Log("Removing " + t.Length + " old opcodes.");
        for (int i = t.Length-1; i >= 0; i--)
        {
            //Destroy the extras
            Destroy(t[i].gameObject);
        }

        //Create new children
        foreach (Instruction.OPCODE code in allowedOpCodes)
        {
            GameObject g = Instantiate(InstructionButtonPrefab) as GameObject;
            ((RectTransform)g.transform).SetParent(panel.transform);
            InstructionButton i = g.GetComponent<InstructionButton>();
            i.opcode = code;
        }
    }
}
