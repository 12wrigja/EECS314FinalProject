using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Toolbox : MonoBehaviour {

	// Class creates, destroys, and allows effects on 
	public Image arrow;
	public Image predictor;
	public Image hardware;

	public Color boxColor;

	private Image[] toolbox;

	void Start () {
	}
	
	public void SpawnBox(Vector3 position, Vector3 scale, Transform canvas){
//		Button box = new Button();
//		box.colors.normalColor = boxColor;
//		box.interactable = false; // Creates non-interactable box.
//		box.transform.position = position;
//		box.transform.localScale = scale;
//		box.transform.SetParent (canvas, false); // Makes box a child of the canvas.
//
//		Image arrow = Instantiate(arrow) as Image; // Creates an arrow.
//		arrow.transform.position = box.transform.position - new Vector3 (0, 10, 0);
//		arrow.transform.SetParent (box, false);
//
//		Image predictor = Instantiate (predictor) as Image; // Creates a predictor.
//		predictor.transform.position = box.transform.position - new Vector3 (0, 20, 0);
//		predictor.transform.SetParent (box, false);
//
//		Image hardware = Instantiate (hardware) as Image; // Creates hardware.
//		hardware.transform.position = box.transform.position - new Vector3 (0, 30, 0);
//		hardware.transform.SetParent (box, false);
	}
}