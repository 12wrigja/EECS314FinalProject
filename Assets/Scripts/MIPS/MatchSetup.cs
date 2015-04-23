using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(OpcodeRepository))]
public class MatchSetup : MonoBehaviour {

    public OpcodeRepository.OPCODE[] validOpCodes;
    public OpCodePanelManager opcodepanel;

    public Register.REGISTERS[] allowedRegisters;
    public RegisterPanelManager registerPanel;

    public string[] allowedLabels;
    public LabelPanelManager labelPanel;

    public string[] allowedImmediateValues;
    public ImmediatePanelManager immediatePanel;

	// Use this for initialization
	void Start () {
        opcodepanel.SetAvailableOpCodes(validOpCodes);
        registerPanel.SetAvailableRegisters(allowedRegisters);
        immediatePanel.SetAvailableImmediates(allowedImmediateValues);
        labelPanel.SetAvailableLabels(allowedLabels);
	}
}
