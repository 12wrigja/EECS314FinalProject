using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MIPSEmulator : MonoBehaviour
{

    private IList<Instruction> bytecode;

    private int pc;

    private static readonly int ZERO = 0;

    private int A0 = 0;

    private int A1 = 0;

    private int A2 = 0;

    private int A3 = 0;

    private int T0 = 0;

    private int T1 = 0;

    private int T2 = 0;

    private int T3 = 0;

    private int T4 = 0;

    private int T5 = 0;

    private int T6 = 0;

    private int T7 = 0;

    private int V0 = 0;

    private int V1 = 0;

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
        return -1;
    }

    private int GetRegisterValue(Register op)
    {
        Type emType = typeof(MIPSEmulator);
        FieldInfo reg = emType.GetField(op.ToFieldString());
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
            reg.SetValue(this, value);
        }
        else
        {
            Debug.Log("Error setting register value");
        }
    }
}
