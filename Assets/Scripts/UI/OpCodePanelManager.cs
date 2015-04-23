using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class OpCodePanelManager : PanelManager {

    public GameObject InstructionButtonPrefab;

    private OpcodeRepository.OPCODE[] allowedOpCodes;
    private GridLayoutGroup panel;

    new void Start()
    {
        base.Start();
        panel = GetComponentInChildren<GridLayoutGroup>();
        RefreshPanel();
        Debug.Log(panel.name);
    }

    public void SetAvailableOpCodes(params OpcodeRepository.OPCODE[] codes)
    {
        this.allowedOpCodes = codes;
        if (panel != null)
        {
            RefreshPanel();
        }
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
        if (allowedOpCodes == null)
        {
            return;
        }
        foreach (OpcodeRepository.OPCODE code in allowedOpCodes)
        {
            GameObject g = Instantiate(InstructionButtonPrefab) as GameObject;
            ((RectTransform)g.transform).SetParent(panel.transform);
            InstructionButton i = g.GetComponent<InstructionButton>();
            i.code = code;
        }
    }
}
