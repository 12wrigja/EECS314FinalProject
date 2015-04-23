using UnityEngine;
using System.Collections;

public class Label : Operand {

	private string value;

    public Label(string value)
    {
        this.value = value;
    }

    public override string toString() {
        return value;
    }
}
