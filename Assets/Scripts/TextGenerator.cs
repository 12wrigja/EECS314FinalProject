using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour {

	public Text[] text;
	public Canvas canvas;

	private string[][] arithmeticOptions = new string[4][]{null, null, null, null};
	private string[][] memoryOptions = new string[3][]{null, null, null};
	private string[][] branchOptions = new string[4][]{null, null, null, null};

	void Start(){
		string[] arithPart1 = new string[]{"add", "sub"};
		string[] arithPart2 = new string[]{"$t1", "$t2", "$t3"};
		string[] arithPart3 = new string[]{"$t1", "$t2", "$t3"};
		string[] arithPart4 = new string[]{"$t1", "$t2", "$t3"};

		string[] memPart1 = new string[]{"lw", "sw"};
		string[] memPart2 = new string[]{"$t1", "$t2", "$t3"};
		string[] memPart3 = new string[]{"4($t1)", "8($t2)", "12($t3)"};

		string[] branchPart1 = new string[]{"bne", "beq"};
		string[] branchPart2 = new string[]{"$t1", "$t2", "$t3"};
		string[] branchPart3 = new string[]{"$t1", "$t2", "$t3"};
		string[] branchPart4 = new string[]{"Loop", "Lbl"};

		arithmeticOptions [0] = arithPart1;
		arithmeticOptions [1] = arithPart2;
		arithmeticOptions [2] = arithPart3;
		arithmeticOptions [3] = arithPart4;

		memoryOptions [0] = memPart1;
		memoryOptions [1] = memPart2;
		memoryOptions [2] = memPart3;

		branchOptions [0] = branchPart1;
		branchOptions [1] = branchPart2;
		branchOptions [2] = branchPart3;
		branchOptions [3] = branchPart4;
	}

	public string GenerateText(){
		string instruction = GenerateInstruction ();
		return instruction;

	}

	private string GenerateInstruction(){
		int instructionType = Random.Range (0, 3);
		string[][] options;
		string instruction;
		if (instructionType == 0) {
			options = arithmeticOptions;
			instruction = DetermineArithmeticInstruction (options);
		} else if (instructionType == 1) {
			options = memoryOptions;
			instruction = DetermineMemoryInstruction (options);
		} else if (instructionType == 2) {
			options = branchOptions;
			instruction = DetermineBranchInstruction (options);
		} else {
			instruction = null;
		}
		return instruction;
	}

	private string DetermineArithmeticInstruction(string[][] options){
		string part1 = options [0] [Random.Range (0, 2)];
		string part2 = options [1] [Random.Range (0, 3)];
		string part3 = options[2][Random.Range (0,3)];
		string part4 = options [3] [Random.Range (0, 3)];
		string composite = part1 + " " + part2 + ", " + part3 + ", " + part4;
		return composite;
	}

	private string DetermineMemoryInstruction(string[][] options){
		string part1 = options [0] [Random.Range (0, 2)];
		string part2 = options [1] [Random.Range (0, 3)];
		string part3 = options[2][Random.Range (0,3)];
		string composite = part1 + " " + part2 + ", " + part3;
		return composite;
	}

	private string DetermineBranchInstruction(string[][] options){
		string part1 = options [0] [Random.Range (0, 2)];
		string part2 = options [1] [Random.Range (0, 3)];
		string part3 = options[2][Random.Range (0,3)];
		string part4 = options [3] [Random.Range (0, 2)];
		string composite = part1 + " " + part2 + ", " + part3 + ", " + part4;
		return composite;
	}

	private string DetermineHazards(){
		return null;
	}
}
