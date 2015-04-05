using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(OpcodeRepository))]
public class MatchSetup : MonoBehaviour {

    public OpcodeRepository.OPCODE[] validOpCodes;
    public OpCodePanelManager opcodepanel;

	// Use this for initialization
	void Start () {
        opcodepanel.SetAvailableOpCodes(validOpCodes);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
