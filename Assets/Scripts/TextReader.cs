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
	public Image arrow;

	public AudioClip buttonClip;
	public AudioClip donutAppear;

	private int numItr = 0;
	private string nextLine;
	private StreamReader reader;
	private bool stopReading;

	private bool clicked1;
	private bool clicked2; // Bools for demo hazard resolutions.

	void Start () {
		reader = new StreamReader (scriptAddress);
		nextLine = reader.ReadLine ();
		tutorialText.text = nextLine;
		stopReading = false;
	}
	
	void Update () {
		if (!stopReading && numItr > 50) {
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
		if (Input.GetKeyDown (KeyCode.Space) && !stopReading && (numItr >= 10 && numItr <= 50) ) {
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
		if(Input.GetKey(KeyCode.Space) && !stopReading && numItr == 19){
			handler.DisplayHazard (1, 2, 2, 1);
		}
		if (Input.GetKey(KeyCode.Space) && !stopReading && numItr == 24) {
			arrow.gameObject.SetActive(true);
			handler.ResolveHazard (1, 2, 2, 1);
		}
		if (Input.GetKey(KeyCode.Space) && !stopReading && numItr == 26) {
			arrow.gameObject.SetActive(false);
			handler.ClearAllInstructions();
		}
		if (Input.GetKey(KeyCode.Space) && !stopReading && numItr == 27) {
			handler.GenerateInstruction(new Vector3(-170f, 120f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-100f, 50f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-30f, -20f, 0), new Vector3(0.5f, 0.5f, 0.5f));
		}
		if(Input.GetKey(KeyCode.Space) && !stopReading && numItr == 28){
			handler.DisplayHazard (1, 2, 2, 1);
		}
		if (Input.GetKey(KeyCode.Space) && !stopReading && numItr == 36) {
			handler.ResolveHazard (1, 2, 2, 1);
		}
		if (Input.GetKey(KeyCode.Space) && !stopReading && numItr == 37) {
			handler.ClearAllInstructions();
		}
		if(Input.GetKey(KeyCode.Space) && !stopReading && numItr == 39){
			handler.GenerateInstruction(new Vector3(-170f, 120f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-100f, 50f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-30f, -20f, 0), new Vector3(0.5f, 0.5f, 0.5f));
		}
		if(Input.GetKey(KeyCode.Space) && !stopReading && numItr == 41){
			handler.DisplayHazard (1, 2, 2, 1);
		}
		if (Input.GetKey(KeyCode.Space) && !stopReading && numItr == 44) {
			handler.ResolveHazard (1, 2, 2, 1);
		}
		if (Input.GetKey (KeyCode.Space) && !stopReading && numItr == 47) {
			handler.ClearAllInstructions();
		}
	}
}
