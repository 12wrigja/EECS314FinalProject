using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {
	
	public Manager man;
	public int x, y;
	public string[] inputs;
	public string type;

	void Start(){
		man = GameObject.FindWithTag ("Manager").GetComponent<Manager> () as Manager;
	}
	
	// Update is called once per frame
	void Update () { //sets new position to progressively closer to destination, makes a smooth transition
		transform.position += (new Vector3 ((x - transform.position.x) * .2f, (y - transform.position.y) * .2f, 0));
	}
	
	void OnMouseDown(){
		man.clicked (this);
	}
}
