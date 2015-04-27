using UnityEngine;
using System.Collections;

public class Tiler : MonoBehaviour {

	public GameObject tilePrefab;
	public GameObject wallPrefab;
	public int width = 1; // Room width
	public int height = 1; // Room height
	private float spacing = 0.3f; // x axis tile spacing
	private GameObject tile;

	void Start () {
		// Creates floor tiles.
		for (int i = -10; i < width; i++) {
			for(int j = -10; j < height; j++){
				Vector3 position = new Vector3(i , j , 0) * spacing;
				Instantiate(tilePrefab, position, Quaternion.identity);
			}
		}
		//Creates walls.
		for(int i = -10; i < width; i++){
			for(int j = 0; j < 3; j++){
				Vector3 position = new Vector3(i, 3 + j, 0) * spacing;
				Instantiate(wallPrefab, position, Quaternion.identity);
			}
		}	
	}
	
	void Update () {
	
	}
}
