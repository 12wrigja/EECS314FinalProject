using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class OpCodePanelManager : PanelManager {

    public GameObject InstructionButtonPrefab;

    private Instruction.OPCODE[] allowedOpCodes;
    private GridLayoutGroup panel;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAvailableOpCodes(params Instruction.OPCODE[] codes)
    {
        this.allowedOpCodes = codes;
    }

    public void RefreshPanel()
    {
        //Remove all old children
        Transform[] t = panel.gameObject.GetComponentsInChildren<Transform>();
        for (int i = t.Length; i >= 0; i++)
        {
            //Destroy the extras
            Destroy(t[i].gameObject);
        }

        //Create new children
        foreach (Instruction.OPCODE code in allowedOpCodes)
        {
            GameObject g = Instantiate(InstructionButtonPrefab) as GameObject;
            Instruction i = g.GetComponent<Instruction>();
            i.SetOpCode(code);
        }
    }
}
