using UnityEngine;
using System.Collections;

public class Toolbox : MonoBehaviour {

	private enum Tool{
		FORWARD,
		PREDICT,
		HARDWARE
	};

	void Start () {
		Tool forward = Tool.FORWARD;
		Tool predict = Tool.PREDICT;
		Tool hardware = Tool.HARDWARE;
	}
	
	public void SpawnBox(){

	}
}