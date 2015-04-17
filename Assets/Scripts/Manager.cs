using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

	public static int width = 8;
	public static int height = 8;
	public Gem[] gems;
	private Gem[,] grid;

	private Gem selected = null;

	void Start(){
		grid = new Gem[width,height];
		for (int i = 0; i < height; i++) {
			for(int j = 0; j < width; j++){
				int index = Random.Range(0, gems.Length );
				Gem gem = gems[index];								//picks a random item
				grid[i,j] = Instantiate(gem);						//makes it
				grid[i,j].transform.position = new Vector2(i, j);	//positions
				grid[i,j].color = index;							//sets its ID field
				grid[i,j].x = i;									//location fields
				grid[i,j].y = j;
			}
		}
		checkMatches();												//gets rid of any starting matches
	}

	// Update is called once per frame
	void Update () {

	}

	public void clicked(Gem select){
		if (!selected) { //if this was first selected
			selected = select;
		}
		else { //there was a previously selected
			if(distance(selected, select) == 1){		//if within swap range, swaps and checks for matches
				Swap(select, selected);
				checkMatches();
			}
			selected = null;
		}
	}

	public void checkMatches(){//only checks horizontal, as intructions won't be vertical
		int color = -1;														//initialization
		int count = 0;														
		Queue<Gem> matches = new Queue<Gem> ();
		for (int j = 0; j < width; j++) {
			for(int i = 0; i < height; i++){
				if(color == grid[i,j].color){								//keeps track of same color in a row
					count++;
					matches.Enqueue(grid[i,j]);
				}
				else{
					if(color != -1 && count >= matches.Peek().reqNumber)	//if chain was long enough, take care of it
						StartCoroutine("lineComplete",matches);
					matches = new Queue<Gem>();								//if different, reinitializes
					matches.Enqueue(grid[i,j]);
					count = 1;
					color = grid[i,j].color;
				}
			}
		}
	}

	public IEnumerator lineComplete(Queue<Gem> matches){							//in this case, removes the line
		foreach(Gem a in matches){
			yield return new WaitForSeconds(.2f);
			a.GetComponent<SpriteRenderer>().enabled = false;
			a.color = -2;
		}
	}

	private float distance(Gem a, Gem b){ //returns 1 if pieces are adjacent, including diagonals as adjacent
		return Mathf.Max (Mathf.Abs(a.x - b.x),
		                  Mathf.Abs (a.y - b.y));
	}

	private void Swap(Gem a, Gem b){	//simple swaps between all the fields, with temp variables
		Gem temp = grid [a.x, a.y];
		grid [a.x, a.y] = grid [b.x, b.y];
		grid [b.x, b.y] = temp;
		int temp2 = a.x;
		a.x = b.x;
		b.x = temp2;
		temp2 = a.y;
		a.y = b.y;
		b.y = temp2;
	}
}
