using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {
	
	public Manager man;

	void Start(){
		man = GameObject.FindWithTag ("Manager").GetComponent<Manager> () as Manager;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool sameType(Gem other){
		return GetComponent<SpriteRenderer> ().sprite == GetComponent<SpriteRenderer> ().sprite;
	}

	void OnMouseDown(){
		man.clicked (this);
	}
}
