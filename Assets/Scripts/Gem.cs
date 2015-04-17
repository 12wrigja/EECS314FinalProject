using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {
	
	public Manager man;
	public int color;
	public int x, y;
	public int reqNumber = 3;

	void Start(){
		man = GameObject.FindWithTag ("Manager").GetComponent<Manager> () as Manager;
	}
	
	// Update is called once per frame
	void Update () { //sets new position to progressively closer to destination, makes a smooth transition
		transform.position += (new Vector3 ((x - transform.position.x) * .2f, (y - transform.position.y) * .2f, 0));
	}

	public bool sameType(Gem other){
		return GetComponent<SpriteRenderer> ().sprite == GetComponent<SpriteRenderer> ().sprite;
	}

	void OnMouseDown(){
		man.clicked (this);
	}
}
