using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnInstruction : MonoBehaviour {
	
	public Image[] donutsInit;
	public Transform canvas;

	private Image[] donuts;

	void Start(){
		Spawn(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
	}

	public void Spawn(Vector3 initialPosition, Vector3 scale){
		for(int i = 0; i < 5; i++){
			donuts[i] = Instantiate(donutsInit[i]) as Image;
			donuts[i].transform.SetParent(canvas, false);
//			donuts[i].transform.localScale = scale;
//			donuts[i].transform.localPosition = new Vector3(initialPosition.x + (i * 10), initialPosition.y, initialPosition.z);
		}
	}
}
