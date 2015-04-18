using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstructionHandler : MonoBehaviour {

	// Generates instructions, removes instructions, illustrates hazards.
	public Image[] donuts;
	public Canvas canvas;

	public void GenerateInstruction(Vector3 position, Vector3 scale){
		Image[] donutInstances = new Image[5];
		for (int i = 0; i < donuts.GetLength(0); i++) {
			donutInstances[i] = Instantiate(donuts[i]) as Image;
			donutInstances[i].transform.position = new Vector3(position.x + (i * 70), position.y, position.z);
			donutInstances[i].transform.localScale = scale;
			donutInstances[i].transform.SetParent(canvas.transform, false);
			donutInstances[i].gameObject.SetActive(true);
		}
	}
}
