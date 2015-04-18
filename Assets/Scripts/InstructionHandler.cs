using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InstructionHandler : MonoBehaviour {

	// Generates instructions, removes instructions, illustrates hazards.
	public Image[] donuts;
	public Canvas canvas;
	public Color fadeTo;

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

	public void DisplayHazard(int firstInstruction, int secondInstruction, int donutNum1, int donutNum2){
		Image[][] orderedInstructions = sceneInstructions.ToArray ();
		Image[] firstArray = orderedInstructions [firstInstruction];
		Image[] secondArray = orderedInstructions [secondInstruction];
		firstArray [donutNum1].CrossFadeColor (fadeTo, 1f, false, false);
		secondArray [donutNum2].CrossFadeColor (fadeTo, 1f, false, false);
	}
}
