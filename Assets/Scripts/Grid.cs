using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public static int width = 8;
	public static int height = 8;
	public Gem[] gems;
	private GameObject[,] grid;

	void Start(){
		grid = new GameObject[width,height];
		for (int i = 0; i < height; i++) {
			for(int j = 0; j < width; j++){
				Gem gem = gems[Random.Range(0, gems.Length)];
				grid[i,j] = Instantiate(gem, new Vector2(i, j), Quaternion.identity) as GameObject;

			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
