using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	public Transform cloudPrefab;
	private Transform cloud;

	void Start () {
		cloud = Instantiate (cloudPrefab) as Transform;
	}
	
	void Update () {
//		cloud.position.x = cloud.position.x + Time.deltaTime;
	}
}
