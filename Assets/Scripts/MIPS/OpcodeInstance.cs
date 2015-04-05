using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class OpcodeRepository : MonoBehaviour{

    private static readonly Dictionary<OPCODE, CODETYPE> typeMap = new Dictionary<OPCODE, CODETYPE>()
    {
        {OPCODE.ADD,CODETYPE.R},
        {OPCODE.ADDI, CODETYPE.I},
        {OPCODE.AND, CODETYPE.I},
        {OPCODE.ANDI, CODETYPE.I},
        {OPCODE.BEQ, CODETYPE.I},
        {OPCODE.BNE, CODETYPE.I},
        {OPCODE.J, CODETYPE.J},
        {OPCODE.JR, CODETYPE.R},
        {OPCODE.LW, CODETYPE.I},
        {OPCODE.NOR, CODETYPE.R},
        {OPCODE.OR, CODETYPE.R},
        {OPCODE.ORI, CODETYPE.I},
        {OPCODE.SLL, CODETYPE.R},
        {OPCODE.SRL, CODETYPE.R},
        {OPCODE.SW, CODETYPE.I},
        {OPCODE.SUB, CODETYPE.R},
        {OPCODE.MULT, CODETYPE.R},
        {OPCODE.BLT, CODETYPE.I},
        {OPCODE.BGT, CODETYPE.I},
        {OPCODE.BLE, CODETYPE.I},
        {OPCODE.BGE, CODETYPE.I},
        {OPCODE.LI, CODETYPE.I},
        {OPCODE.MOVE, CODETYPE.I}
    };

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

    public enum CODETYPE{
        R,I,J
    }

    public CODETYPE getTypeForOpCode(OPCODE code)
    {
        return typeMap[code];
    }

}
