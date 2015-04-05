using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class InstructionButton : MonoBehaviour {

    public OpcodeRepository.OPCODE code;
    public Text instructionNameText;

	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => CodeAreaManager.addInstructionLine(code));
	}
	
	// Update is called once per frame
	void Update () {
        if (instructionNameText != null && code != null)
        {
            instructionNameText.text = code.ToString();
        }
	}
}
