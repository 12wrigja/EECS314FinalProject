using UnityEngine;
using System.Collections;

public class TouchCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch Count: " + Input.touchCount);
        }
	}
}
