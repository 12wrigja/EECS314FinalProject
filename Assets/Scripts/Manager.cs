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
			select.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			select.transform.position = new Vector3(select.transform.position.x, select.transform.position.y, -1);
		}
		else { //there was a previously selected
			if(distance(selected, select) == 1){		//if within swap range, swaps and checks for matches
				Swap(select, selected);
				checkMatches();
				Debug.Log ("end");
			}
			selected.transform.localScale = new Vector3(1, 1, 1);
			select.transform.position = new Vector3(select.transform.position.x, select.transform.position.y, 1);
			selected = null;
		}
	}
	
	public void checkMatches(){//only checks horizontal, as intructions won't be vertical														
		int count;																//initialization				
		Queue<Gem> matches;
		for (int j = 0; j < width; j++) {
			for(int i = 0; i < height; i++){
				if(grid[i,j] is Op && grid[i,j]){ //if its the operation
					count = 0;
					matches = new Queue<Gem> ();
					matches.Enqueue(grid[i,j]);
					for(int k = 1; k <= grid[i,j].inputs.Length; k++){ //runs through the next gems that could be inputs
						if(i + k < width && grid[i + k, j].type != null && grid[i + k, j].type.Equals(grid[i,j].inputs[k - 1])){
							count++; //if its the correct inputs, increment
							matches.Enqueue(grid[i + k, j]);
						}
					}
					if(count >= grid[i,j].inputs.Length) //if all inputs are correctly filled, complete the line
						StartCoroutine("lineComplete", matches);
					Debug.Log (count);
				}
			}
		}
	}
	
	public IEnumerator lineComplete(Queue<Gem> matches){							//in this case, removes the line
		foreach(Gem a in matches){
			yield return new WaitForSeconds(.2f);
			a.GetComponent<SpriteRenderer>().enabled = false;
			grid[a.x, a.y] = new Nop();
			grid[a.x, a.y].x = a.x;
			grid[a.x, a.y].y = a.y;
			a.x = -1;
			a.y = -1;
			a.type = null;
		}
		dropLines();
	}
	
	public void dropLines()
	{
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				if (grid[j, i] is Nop)
				{
					for (int tempHeight = i + 1; tempHeight < height; tempHeight++)
					{
						if (grid[j, tempHeight] != null)
						{
							Swap (grid[j,i], grid[j, tempHeight]);
						}
					}
				}
			}
		}
		checkMatches();
	}
	
	private float distance(Gem a, Gem b)
	{ //returns 1 if pieces are adjacent, including diagonals as adjacent
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
