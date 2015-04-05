using UnityEngine;
using System.Collections;

public class Register : Operand {

    public enum REGISTERS
    {
        ZERO,
        A0,
        A1,
        A2,
        A3,
        T0,
        T1,
        T2,
        T3,
        T4,
        T5,
        T6,
        T7,
        V0,
        V1
    }

    public REGISTERS reg;

    public override string toString()
    {
        return reg.ToString();
    }
}
