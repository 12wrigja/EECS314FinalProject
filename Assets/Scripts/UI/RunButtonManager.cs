using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UI;

public class RunButtonManager : MonoBehaviour
{

    private static RunButtonManager instance;

    public ConfirmDialog confirmBox;

    public Button RunButton;
    public GameObject codeContainer;

	// Use this for initialization
	void Start ()
	{
	    instance = this;
	    RunButton.onClick.AddListener(() => RunProgram());
        instance.confirmBox.AddConfirmListener(() => CloseBox());
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
            Debug.Log(child.gameObject.GetComponent<Instruction>().op3);
            program.Add(child.gameObject.GetComponent<Instruction>());
            Debug.Log(child.gameObject.GetComponent<Instruction>().code.ToString());
        }

        MIPSEmulator emulator = new MIPSEmulator("");
        emulator.ExecuteProgram(program);
        Debug.Log(emulator.V0);

        instance.confirmBox.contentText.text = "Results: V0: " + emulator.V0;
        instance.confirmBox.showPanel();

    }

    public void CloseBox()
    {
       instance.confirmBox.hidePanel(); 
    }
}
