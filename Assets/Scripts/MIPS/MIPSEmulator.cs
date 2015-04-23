using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MIPSEmulator
{

    private IList<Instruction> bytecode;

    private int pc;

    private static readonly int ZERO = 0;

    public int A0 = 1;

    public int A1 = 0;

    public int A2 = 0;

    public int A3 = 0;

    public int T0 = 0;

    public int T1 = 0;

    public int T2 = 0;

    public int T3 = 0;

    public int T4 = 0;

    public int T5 = 0;

    public int T6 = 0;

    public int T7 = 0;

    public int V0 = 0;

    public int V1 = 0;

    private string correctState;

    public MIPSEmulator(string answer)
    {
        this.correctState = answer;
    }

    public void ExecuteProgram(IList<Instruction> program)
    {
        bytecode = program;
        pc = 0;

        while (pc < bytecode.Count)
        {
            pc++;
            RunInstruction(bytecode[pc -1]);
            
        }
    }

    private void RunInstruction(Instruction inst)
    {
        switch (inst.code)
        {
            case OpcodeRepository.OPCODE.ADD:
            case OpcodeRepository.OPCODE.ADDI:
                SetRegister((Register)inst.op1, InterpretValue(inst.op2) + InterpretValue(inst.op3));
                break;
            case OpcodeRepository.OPCODE.SUB:
                SetRegister((Register)inst.op1, InterpretValue(inst.op2) - InterpretValue(inst.op3) );
                break;
            case OpcodeRepository.OPCODE.AND:
            case OpcodeRepository.OPCODE.ANDI:
                SetRegister((Register)inst.op1, InterpretValue(inst.op2) & InterpretValue(inst.op3));
                break;
            case OpcodeRepository.OPCODE.OR:
            case OpcodeRepository.OPCODE.ORI:
                SetRegister((Register)inst.op1, InterpretValue(inst.op2) | InterpretValue(inst.op3));
                break;
            case OpcodeRepository.OPCODE.SLL:
                SetRegister((Register)inst.op1, InterpretValue(inst.op2) << 1);
                break;
            case OpcodeRepository.OPCODE.SRL:
                SetRegister((Register)inst.op1, InterpretValue(inst.op2) >> 1);
                break;
            default:
                Debug.Log("Op" + inst.op1.toString() + "Not implemented yet");
                break;
        }
    }

    private int InterpretValue(Operand op)
    {
        if (op is Register)
        {
            return GetRegisterValue((Register)op);
        }
        else
        {
            return int.Parse(op.toString());
        }
    }

    private int GetRegisterValue(Register op)
    {
        Type emType = typeof(MIPSEmulator);
        string registring = op.ToFieldString();
        FieldInfo reg = emType.GetField(registring);
        if (reg != null && reg.GetValue(this) is int)
        {
            return (int)reg.GetValue(this);
        }
        else
        {
            Debug.Log("Error getting register Value");
        }

        return -1;
    }

    private void SetRegister(Register op, int value)
    {
        Type emType = typeof(MIPSEmulator);
        FieldInfo reg = emType.GetField(op.ToFieldString());
        if (reg != null && reg.GetValue(this) is int)
        {
            if (op.ToFieldString().Equals("ZERO"))
            {

            }
            else
            {
                reg.SetValue(this, value);
            }
        }
        else
        {
            Debug.Log("Error setting register value");
        }
    }
}
