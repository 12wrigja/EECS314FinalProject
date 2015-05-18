using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InstructionHandler : MonoBehaviour {

	// Generates instructions, removes instructions, illustrates hazards and hazard resolution.
	public Image[] donuts;
	public Canvas canvas;
	public Text[] text;

	public TextGenerator generator;

	public Color fadeTo;
	public Color fadeFrom;

	private Image[][] orderedInstructions = new Image[3][]{null, null, null};

	private int arrayCounter = 0;

	public void GenerateInstruction(Vector3 position, Vector3 scale){

		Image[] donutInstances = new Image[5];

		for (int i = 0; i < 5; i++) {
			donutInstances[i] = Instantiate(donuts[i]) as Image;
			donutInstances[i].transform.position = new Vector3(position.x + (i * 70), position.y, position.z);
			donutInstances[i].transform.localScale = scale;
			donutInstances[i].transform.SetParent(canvas.transform, false);
			donutInstances[i].gameObject.SetActive(true);
		}
		orderedInstructions [arrayCounter] = donutInstances;

		text [arrayCounter].gameObject.GetComponent<Text> ().text = generator.GenerateText();
		text[arrayCounter].gameObject.SetActive (true);

		arrayCounter++;
	}

	// Turns instructions red upon hazard detection.
	public void DisplayHazard(int firstInstruction, int secondInstruction, int donutNum1, int donutNum2){
		Image[] firstArray = orderedInstructions [firstInstruction];
		Image[] secondArray = orderedInstructions [secondInstruction];
		firstArray [donutNum1].CrossFadeColor (fadeTo, 1f, false, false);
		secondArray [donutNum2].CrossFadeColor (fadeTo, 1f, false, false);
	}
	// Turns instructions green upon hazard resolution.
	public void ResolveHazard(int firstInstruction, int secondInstruction, int donutNum1, int donutNum2){
		Image[] firstArray = orderedInstructions [firstInstruction];
		Image[] secondArray = orderedInstructions [secondInstruction];
		firstArray [donutNum1].CrossFadeColor (fadeFrom, 1f, false, false);
		secondArray [donutNum2].CrossFadeColor (fadeFrom, 1f, false, false);
	}

	// Detects when a donut is clicked in hazard resolution.
	public void DetectClicked(){

	}

	// Clears screen of all instructions.
	public void ClearAllInstructions(){
		for (int i = 0; i < arrayCounter; i++) {
			for (int j = 0; j < 5; j++) {
				Destroy (orderedInstructions[i][j].gameObject);
			}
		}
		orderedInstructions = new Image[3][];
		arrayCounter = 0;
	}
}
