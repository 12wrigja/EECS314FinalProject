using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CodeLine : MonoBehaviour {

    public Text labelText;
    public Text instrText;
    public Text op1Text;
    public Text op2Text;
    public Text op3Text;

    public Button lineAdjustButton;
    public Button labelButton;
    public Button instructionButton;
    public Button op1Button;
    public Button op2Button;
    public Button op3Button;

    private string label;
    private Instruction instr;

    void Awake()
    {
        instr = gameObject.GetComponent<Instruction>();
    }

    public CodeLine SetLabel(string label)
    {
        this.label = label;
        if (labelText != null)
        {
            labelText.text = label;
        }
        return this;
    }

    public CodeLine setupLine(OpcodeRepository.OPCODE code)
    {
        instr.code = code;
        if (instrText != null)
        {
            instrText.text = code.ToString();
        }
        lineAdjustButton.onClick.AddListener(() => LineAdjuster.ShowAdjusterForLine(this));

        //Register each of the operands to their appropriate listeners.
        for (int i = 0; i < 3; i++)
        {
            if (OpcodeRepository.indexUnused(code, i))
            {
                disableOperandText(i);
                continue;
            }
            if (OpcodeRepository.canPlaceRegister(code, i))
            {
                RegisterPanelManager.RegisterAsRegisterSlot(this, getButtonForOperandIndex(i), getTextForOperandIndex(i), i);
                getTextForOperandIndex(i).text = "register";
            }
            if (OpcodeRepository.canPlaceImmediate(code, i))
            {
                ImmediatePanelManager.RegisterAsRegisterSlot(this, getButtonForOperandIndex(i), getTextForOperandIndex(i), i);
                getTextForOperandIndex(i).text = "immediate";
            }
            if (OpcodeRepository.canPlaceLabel(code, i))
            {
                LabelPanelManager.RegisterAsLabelSlot(this, getButtonForOperandIndex(i), getTextForOperandIndex(i), i);
                getTextForOperandIndex(i).text = "label";
            }

            //TOOD add in the ability to place memory locations
        }
        LabelPanelManager.RegisterAsLabelSlot(this, labelButton, labelText);
        return this;
    }

    public void cleanup()
    {
        for (int i = 0; i < 3; i++)
        {
            Button opBtn = getButtonForOperandIndex(i);
            RegisterPanelManager.DeregisterAsRegisterSlot(opBtn);
            LabelPanelManager.DeregisterAsLabelSlot(opBtn);
            ImmediatePanelManager.DeregisterAsImmediateSlot(opBtn);
        }
    }

    private Text getTextForOperandIndex(int i){
        switch(i){
            case 0:
                return op1Text;
            case 1:
                return op2Text;
            case 2:
                return op3Text;
            default: return null;
        }
    }

    private Button getButtonForOperandIndex(int i)
    {
        switch (i)
        {
            case 0:
                return op1Button;
            case 1:
                return op2Button;
            case 2:
                return op3Button;
            default: 
                return null;
        }
    }

    private void disableOperandText(int i){
        switch(i){
            case 0:
                op1Button.enabled = false;
                op1Text.color = new Color(op1Text.color.r, op1Text.color.g, op1Text.color.b, 0);
                break;
            case 1:
                op2Button.enabled = false;
                op2Text.color = new Color(op2Text.color.r, op2Text.color.g, op2Text.color.b, 0);
                break;
            case 2:
                op3Button.enabled = false;
                op3Text.color = new Color(op3Text.color.r, op3Text.color.g, op3Text.color.b, 0);
                break;
            default: 
                break;
        }
    }

    public CodeLine setOperand1(Operand op)
    {
        instr.op1 = op;
        if (op1Text != null)
        {
            op1Text.text = op.toString();
        }
        return this;
    }

    public CodeLine setOperand2(Operand op)
    {
        instr.op2 = op;
        if (op2Text != null)
        {
            op2Text.text = op.toString();
        }
        return this;
    }

    public CodeLine setOperand3(Operand op)
    {
        instr.op3 = op;
        if (op3Text != null)
        {
            op3Text.text = op.toString();
        }
        return this;
    }
}
