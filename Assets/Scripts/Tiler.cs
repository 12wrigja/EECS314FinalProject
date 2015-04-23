using UnityEngine;
using System.Collections;

public class Tiler : MonoBehaviour {

	public GameObject tilePrefab;
	public GameObject wallPrefab;
	public int width = 2; // Room width
	public int height = 2; // Room height
	private float spacing = 0.3f; // x axis tile spacing
	private GameObject tile;

	void Start () {
		// Creates floor tiles.
		for (int i = -3; i < width; i++) {
			for(int j = -3; j < height; j++){
				Vector3 position = new Vector3(i , j , 0) * spacing;
				Instantiate(tilePrefab, position, Quaternion.identity);
			}
		}
		//Creates walls.
		for(int i = -3; i < width; i++){
			Vector3 position = new Vector3(i, 3, 0) * spacing;
			Instantiate(wallPrefab, position, Quaternion.identity);
		}
	}
	
	void Update () {
	
	}
}
