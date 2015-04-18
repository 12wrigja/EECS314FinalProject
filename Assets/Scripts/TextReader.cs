using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TextReader : MonoBehaviour {

	public string scriptAddress;

	public InstructionHandler handler;

	public Text tutorialText;
	public Image[] donuts;

	public AudioClip buttonClip;
	public AudioClip donutAppear;

	private int numItr = 0;
	private string nextLine;
	private StreamReader reader;
	private bool stopReading;

	void Start () {
		reader = new StreamReader (scriptAddress);
		nextLine = reader.ReadLine ();
		tutorialText.text = nextLine;
		stopReading = false;
	}
	
	void Update () {
		if (!stopReading && numItr > 18) {
			stopReading = true;
		}
		if(Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr < 5){
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			GetComponent<AudioSource>().PlayOneShot(buttonClip, 2.5f);// Plays beep noise.
			numItr++;
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr >= 5 && numItr < 10) { // Makes donuts appear on fifth tap.
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			donuts[numItr - 5].gameObject.SetActive(true);
			GetComponent<AudioSource>().PlayOneShot(donutAppear, 0.1f); //Plays donut appear sound for each donut.
			numItr++;
		}
		if (Input.GetKeyDown (KeyCode.Space) && !stopReading && (numItr >= 10 && numItr <= 18) ) {
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			GetComponent<AudioSource>().PlayOneShot(buttonClip, 2.5f);// Plays beep noise.
			numItr++;
		}
		if (Input.GetKeyDown (KeyCode.Space) && !stopReading && numItr == 16) {
			for(int i = 0; i < 5; i++){
				donuts[i].gameObject.SetActive(false);
			}
			handler.GenerateInstruction(new Vector3(-170f, 120f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-100f, 50f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-30f, -20f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			GetComponent<AudioSource>().PlayOneShot(donutAppear, 0.1f); //Plays donut appear sound.
			numItr++;
		}
	}
}
