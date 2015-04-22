using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UI;

public class RunButtonManager : MonoBehaviour
{

    public Button RunButton;
    public GameObject codeContainer;

	// Use this for initialization
	void Start () {
	    RunButton.onClick.AddListener(() => RunProgram());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RunProgram()
    {
        Debug.Log("Clicked"); 
        List<Instruction> program = new List<Instruction>();

        

        foreach (Transform child in codeContainer.transform)
        {
            program.Add(child.gameObject.GetComponent<Instruction>());
            Debug.Log(child.gameObject.GetComponent<Instruction>().code.ToString());
        }

        MIPSEmulator emulator = new MIPSEmulator("");
        emulator.ExecuteProgram(program);
        Debug.Log(emulator.V0);
  
    }
}
