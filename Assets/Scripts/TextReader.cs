using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TextReader : MonoBehaviour {

	public string scriptAddress;
	public Text tutorialText;
	public AudioClip buttonClip;
	private string nextLine;
	private StreamReader reader;
	private bool stopReading = false;

	void Start () {
		reader = new StreamReader (scriptAddress);
		nextLine = reader.ReadLine ();
		tutorialText.text = nextLine;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !reader.EndOfStream && !stopReading){
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			GetComponent<AudioSource>().PlayOneShot(buttonClip, 1.5f);// Plays beep noise.
		}
		if (!stopReading && reader.EndOfStream) {
			reader.Close ();
			stopReading = true;
		}
	}
}
