using UnityEngine;
using System.Collections;

public class BakerMove : MonoBehaviour {

	private Animator anim;
	private Vector3 wVector;
	private Vector3 aVector;
	private Vector3 sVector;
	private Vector3 dVector;
	private static string prev = "toIdle";

	void Start () {
		anim = GetComponent<Animator> ();
		wVector = new Vector3 (0, 1, 0);
		aVector = new Vector3 (1, 0, 0);
		sVector = new Vector3 (0, -1, 0);
		dVector = new Vector3 (-1, 0, 0);
	}
	
	void Update () {
//		while(transform.position != Input.GetTouch(0).position){
//			transform.position = Input.GetTouch(0).deltaTime * Input.GetTouch(0).position;
//		}
	
		if(Input.GetButton("Up")){
			anim.SetBool(prev, false);
			anim.SetBool("moveBackward", true);
			prev = "moveBackward";
			transform.position += Time.deltaTime * wVector;
		}
		if(Input.GetButton("Left")){
			anim.SetBool(prev, false);
			anim.SetBool("moveLeft", true);
			prev = "moveLeft";
			transform.position += Time.deltaTime * aVector;
		}
		if(Input.GetButton("Down")){
			anim.SetBool(prev, false);
			Debug.Log (prev);
			anim.SetBool("moveForward", true);
			prev = "moveForward";
			Debug.Log (prev);
			transform.position += Time.deltaTime * sVector;
		}
		if(Input.GetButton("Right")){
			anim.SetBool(prev, false);
			Debug.Log(prev);
			anim.SetBool("moveRight", true);
			prev = "moveRight";
			Debug.Log(prev);
			transform.position += Time.deltaTime * dVector;
		}
		if(!Input.GetButton("Right") && !Input.GetButton("Down") && ! Input.GetButton("Left") && !Input.GetButton("Up")){
			anim.SetBool(prev, false);
			anim.SetBool("toIdle", true);
			prev = "toIdle";
		}
	}
}
