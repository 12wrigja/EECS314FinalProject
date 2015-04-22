using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public void executeProgram(IList<Instruction> program)
    {
        bytecode = program;
        pc = 0;

        while (pc < bytecode.Count)
        {
            pc++;
            runInstruction(bytecode[pc -1]);
            
        }
    }

    public void runInstruction(Instruction inst)
    {
        
    }

    /*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
