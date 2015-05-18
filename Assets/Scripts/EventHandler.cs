using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public BakerMove mover;
	public InstructionHandler handler;

	void Start () {
		handler.GenerateInstruction (new Vector3 (-270f, -20f, -20f), new Vector3 (0.4f, 0.4f, 0.4f));
		handler.GenerateInstruction (new Vector3 (-200f, -80f, -20f), new Vector3 (0.4f, 0.4f, 0.4f));
		handler.GenerateInstruction (new Vector3 (-130f, -140f, -20f), new Vector3 (0.4f, 0.4f, 0.4f));
	}
	
	void Update () {
	
	}
}
