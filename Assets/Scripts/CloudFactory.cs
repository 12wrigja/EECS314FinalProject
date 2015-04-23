using UnityEngine;
using System.Collections;

public class CloudFactory : MonoBehaviour {

	private CloudScript cloud;

	void Update () {
		if (Random.Range (0, 500) > 499) { // 1 in 500 chance of generating a cloud every frame
			cloud = new CloudScript();
		}
	}
}
