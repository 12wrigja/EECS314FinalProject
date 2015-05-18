using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public BakerMove mover;
	public InstructionHandler handler;

	void Start () {
		handler.GenerateInstruction (new Vector3 (-325f, -20f, -20f), new Vector3 (0.4f, 0.4f, 0.4f));
		handler.GenerateInstruction (new Vector3 (-255f, -80f, -20f), new Vector3 (0.4f, 0.4f, 0.4f));
		handler.GenerateInstruction (new Vector3 (-185f, -140f, -20f), new Vector3 (0.4f, 0.4f, 0.4f));
	}
	
	void Update () {
	
	}
}
