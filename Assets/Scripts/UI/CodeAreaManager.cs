using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CodeAreaManager : MonoBehaviour {

    private static CodeAreaManager instance;

    public GameObject instructionLinePrefab;
    private GridLayoutGroup codeList;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            codeList = GetComponentInChildren<GridLayoutGroup>();
        }
        else
        {
            //Error out.
        }
    }

    public static void addInstructionLine(Instruction.OPCODE opcode)
    {
        if (instance == null)
        {
            Debug.Log("Null instance!");
            return;
        }
        GameObject newLine = Instantiate(instance.instructionLinePrefab) as GameObject;
        ((RectTransform)newLine.transform).SetParent(instance.codeList.transform);
        Instruction i = newLine.GetComponent<Instruction>();
        i.SetOpCode(opcode);
    }

}
