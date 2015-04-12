using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	public Gem up, down, left, right;
	
	// Update is called once per frame
	void Update () {

	}

	public bool sameType(Gem other){
		return GetComponent<SpriteRenderer> ().sprite == GetComponent<SpriteRenderer> ().sprite;
	}
}
