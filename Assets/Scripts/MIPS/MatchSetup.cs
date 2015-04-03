using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchSetup : MonoBehaviour {

    public List<Instruction.OPCODE> validOpCodes;
    public OpCodePanelManager opcodepanel;

	// Use this for initialization
	void Start () {
        opcodepanel.SetAvailableOpCodes(validOpCodes.ToArray());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
