﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class Instruction : MonoBehaviour {

    public enum OPCODE
    {
        ADD,
        ADDI,
        AND,
        ANDI,
        BEQ,
        BNE,
        J,
        JR,
        LW,
        NOR,
        OR,
        ORI,
        SLL,
        SRL,
        SW,
        SUB,
        MULT,
        BLT,
        BGT,
        BLE,
        BGE,
        LI,
        MOVE
    }

    public OPCODE code;

    public void SetOpCode(OPCODE newCode)
    {
        this.code = newCode;
    }

}
