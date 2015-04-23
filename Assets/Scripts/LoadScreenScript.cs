using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScreenScript : MonoBehaviour {

	public AudioClip proceed;
	public Text clickText;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			clickText.gameObject.SetActive(false); // Gets rid of "tap to start" text.
			GetComponent<AudioSource>().PlayOneShot(proceed, 20f); // Plays proceed sound.
			for(int i = 0; i < 500000; i++){ // Stall loop to give noise time to play.
				for(int j = 0; j < 120; j++){
				}
			}
			Application.LoadLevel("Tutorial"); // Loads tutorial. EDIT: Will eventually load selection screen.
		}
	}
}
