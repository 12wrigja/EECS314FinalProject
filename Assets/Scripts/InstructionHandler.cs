using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InstructionHandler : MonoBehaviour {

	// Generates instructions, removes instructions, illustrates hazards and hazard resolution.
	public Image[] donuts;
	public Canvas canvas;
	public Color fadeTo;
	public Color fadeFrom;

	private static int orderInScene = 0;
	private List<Image[]> sceneInstructions;

	void Start(){
		sceneInstructions = new List<Image[]>();
	}

	public void GenerateInstruction(Vector3 position, Vector3 scale){
		Image[] donutInstances = new Image[5];
		sceneInstructions.Add(donutInstances);
		for (int i = 0; i < 5; i++) {
			donutInstances[i] = Instantiate(donuts[i]) as Image;
			donutInstances[i].transform.position = new Vector3(position.x + (i * 70), position.y, position.z);
			donutInstances[i].transform.localScale = scale;
			donutInstances[i].transform.SetParent(canvas.transform, false);
			donutInstances[i].gameObject.SetActive(true);
		}
		orderInScene++;
	}

	// Turns instructions red upon hazard detection.
	public void DisplayHazard(int firstInstruction, int secondInstruction, int donutNum1, int donutNum2){
		Image[][] orderedInstructions = sceneInstructions.ToArray ();
		Image[] firstArray = orderedInstructions [firstInstruction];
		Image[] secondArray = orderedInstructions [secondInstruction];
		firstArray [donutNum1].CrossFadeColor (fadeTo, 1f, false, false);
		secondArray [donutNum2].CrossFadeColor (fadeTo, 1f, false, false);
	}
	// Turns instructions green upon hazard resolution.
	public void ResolveHazard(int firstInstruction, int secondInstruction, int donutNum1, int donutNum2){
		Image[][] orderedInstructions = sceneInstructions.ToArray ();
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
		Image[][] orderedInstructions = sceneInstructions.ToArray ();
		for(int i = 0; i < orderedInstructions.GetLength(0); i++){
			for(int j = 0; j < 5; j++){
				Destroy(orderedInstructions[i][j].gameObject);
			}
		}
		orderInScene = 0;
	}
}
