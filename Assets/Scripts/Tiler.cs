using UnityEngine;
using System.Collections;

public class Tiler : MonoBehaviour {

	public GameObject tilePrefab;
	private int width = 10; // Room width
	private int height = 1; // Room height
	private float spacing = 0.3f; // Tile spacing;
	private GameObject tile;

	void Start () {
		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++){
				Vector3 position = new Vector3(i, 0, j) * spacing;
				Instantiate(tilePrefab, position, Quaternion.identity);
			}
		}
	}
	
	void Update () {
	
	}
}
