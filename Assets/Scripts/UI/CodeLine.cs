using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CodeLine : MonoBehaviour {

    public Text labelText;
    public Text instrText;
    public Text op1Text;
    public Text op2Text;
    public Text op3Text;



    private string label;
    private Instruction instr;

    void Awake()
    {
        instr = gameObject.GetComponent<Instruction>();
    }

    void Update()
    {

    }

    public void MoveLine()
    {
        if (Input.touchCount > 1 && Input.touches[0].phase == TouchPhase.Moved)
        {
            Debug.Log("Being Relocated on screen.");
        }
    }

    public void StartDrag()
    {
        Debug.Log("Code line drag has started.");
    }

    public void StopDrag()
    {
        Debug.Log("Code line drag has stopped.");
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

    public CodeLine setInstruction(OpcodeRepository.OPCODE code)
    {
        instr.code = code;
        if (instrText != null)
        {
            instrText.text = code.ToString();
        }
        return this;
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
