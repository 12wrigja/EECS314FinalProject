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

    private enum OPTYPES
    {
        REG_ONLY,
        IMM_ONLY,
        LABEL_ONLY,
        MEMORY_LOC,
        NONE
    }

    private static readonly Dictionary<OPCODE, OPTYPES[]> allowedOperandTypeMap = new Dictionary<OPCODE, OPTYPES[]>()
    {
        {OPCODE.ADD,new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.REG_ONLY}},
        {OPCODE.ADDI,new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.IMM_ONLY}},
        {OPCODE.AND,new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.REG_ONLY}},
        {OPCODE.ANDI,new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.IMM_ONLY}},
        {OPCODE.BEQ, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.LABEL_ONLY}},
        {OPCODE.BNE, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.LABEL_ONLY}},
        {OPCODE.J, new OPTYPES[]{OPTYPES.LABEL_ONLY,OPTYPES.NONE,OPTYPES.NONE}},
        {OPCODE.JR, new OPTYPES[]{OPTYPES.LABEL_ONLY,OPTYPES.NONE,OPTYPES.NONE}},
        {OPCODE.LW, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.MEMORY_LOC,OPTYPES.NONE}},
        {OPCODE.NOR, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.REG_ONLY}},
        {OPCODE.OR, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.REG_ONLY}},
        {OPCODE.ORI, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.IMM_ONLY}},
        {OPCODE.SLL, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.IMM_ONLY}},
        {OPCODE.SRL, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.IMM_ONLY}},
        {OPCODE.SW, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.MEMORY_LOC,OPTYPES.NONE}},
        {OPCODE.SUB, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.REG_ONLY}},
        {OPCODE.MULT, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.NONE}},
        {OPCODE.BLT, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.LABEL_ONLY}},
        {OPCODE.BGT, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.LABEL_ONLY}},
        {OPCODE.BLE, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.LABEL_ONLY}},
        {OPCODE.BGE, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.LABEL_ONLY}},
        {OPCODE.LI, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.IMM_ONLY,OPTYPES.NONE}},
        {OPCODE.MOVE, new OPTYPES[]{OPTYPES.REG_ONLY,OPTYPES.REG_ONLY,OPTYPES.NONE}}
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

    public static bool canPlaceRegister(OPCODE code, int operandIndex)
    {
        if(operandIndex >=3 || operandIndex < 0){
            throw new IndexOutOfRangeException("There are a maximum of 3 operands!");
        }
        OPTYPES[] validTypes = allowedOperandTypeMap[code];
        if (validTypes != null)
        {
            return validTypes[operandIndex] == OPTYPES.REG_ONLY;
        }
        else
        {
            throw new System.Exception("Opcode not found in dictionary!");
        }
    }

    public static bool canPlaceLabel(OPCODE code, int operandIndex)
    {
        if (operandIndex >= 3 || operandIndex < 0)
        {
            throw new IndexOutOfRangeException("There are a maximum of 3 operands!");
        }
        OPTYPES[] validTypes = allowedOperandTypeMap[code];
        if (validTypes != null)
        {
            return validTypes[operandIndex] == OPTYPES.LABEL_ONLY;
        }
        else
        {
            throw new System.Exception("Opcode not found in dictionary!");
        }
    }

    public static bool canPlaceImmediate(OPCODE code, int operandIndex)
    {
        if (operandIndex >= 3 || operandIndex < 0)
        {
            throw new IndexOutOfRangeException("There are a maximum of 3 operands!");
        }
        OPTYPES[] validTypes = allowedOperandTypeMap[code];
        if (validTypes != null)
        {
            return validTypes[operandIndex] == OPTYPES.IMM_ONLY;
        }
        else
        {
            throw new System.Exception("Opcode not found in dictionary!");
        }
    }

    public static bool canPlaceMemoryLocation(OPCODE code, int operandIndex)
    {
        if (operandIndex >= 3 || operandIndex < 0)
        {
            throw new IndexOutOfRangeException("There are a maximum of 3 operands!");
        }
        OPTYPES[] validTypes = allowedOperandTypeMap[code];
        if (validTypes != null)
        {
            return validTypes[operandIndex] == OPTYPES.MEMORY_LOC;
        }
        else
        {
            throw new System.Exception("Opcode not found in dictionary!");
        }
    }

    public static bool indexUnused(OPCODE code, int operandIndex)
    {
        if (operandIndex >= 3 || operandIndex < 0)
        {
            throw new IndexOutOfRangeException("There are a maximum of 3 operands!");
        }
        OPTYPES[] validTypes = allowedOperandTypeMap[code];
        if (validTypes != null)
        {
            return validTypes[operandIndex] == OPTYPES.NONE;
        }
        else
        {
            throw new System.Exception("Opcode not found in dictionary!");
        }
    }
}
