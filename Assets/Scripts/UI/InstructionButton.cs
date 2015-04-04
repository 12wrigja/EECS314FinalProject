using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstructionButton : MonoBehaviour {

    public Instruction.OPCODE opcode;
    public Text instructionNameText;

	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => CodeAreaManager.addInstructionLine(opcode));
	}
	
	// Update is called once per frame
	void Update () {
        if (instructionNameText != null && opcode != null)
        {
            instructionNameText.text = opcode.ToString();
        }
	}
}
