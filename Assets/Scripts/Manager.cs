using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public static int width = 8;
	public static int height = 8;
	public Gem[] gems;
	private GameObject[,] grid;

	private Gem selected = null;

	void Start(){
		grid = new GameObject[width,height];
		for (int i = 0; i < height; i++) {
			for(int j = 0; j < width; j++){
				Gem gem = gems[Random.Range(0, gems.Length )];	//picks a random item
				grid[i,j] = Instantiate(gem, new Vector2(i,j), Quaternion.identity) as GameObject; //makes and places it
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void clicked(Gem select){
		if (!selected) { //if this was first selected
			selected = select;
		}
		else { //there was a previously selected
			if(distance(selected, select) == 1){
				Swap(select, selected);
			}
			selected = null;
		}
	}

	private float distance(Gem a, Gem b){ //returns 1 if pieces are adjacent, including diagonals as adjacent
		Debug.Log (Mathf.Max (Mathf.Abs(a.transform.position.x - b.transform.position.x),
		                      Mathf.Abs (a.transform.position.y - b.transform.position.y)));
		return Mathf.Max (Mathf.Abs(a.transform.position.x - b.transform.position.x),
		                  Mathf.Abs (a.transform.position.y - b.transform.position.y));
	}

	private void Swap(Gem a, Gem b){
		Vector2 temp = a.transform.position;
		a.transform.position = b.transform.position;
		b.transform.position = temp;
	}
}
