using UnityEngine;
using System.Collections;

public class Immediate : Operand {

    private string value;

    public Immediate(string value)
    {
        this.value = value;
    }

    public override string toString() {
        return value;

    }

}
