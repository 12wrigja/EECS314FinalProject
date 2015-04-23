using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TextReader : MonoBehaviour {

	public string scriptName;

	public InstructionHandler handler;

	public Text tutorialText;
	public Image[] donuts;

	// Represents a temporary toolbox.
	public Image arrow;
	public Image predictor;
	public Image predictor2;
	public Image hardware;

	public Text text1;
	public Text text2;
	public Text text3;

	public AudioClip buttonClip;
	public AudioClip donutAppear;

	private int numItr = 0;
	private string nextLine;
	private StreamReader reader;
	private bool stopReading;

	private bool clicked1;
	private bool clicked2; // Bools for demo hazard resolutions.

	void Start () {
        TextAsset script = Resources.Load(scriptName) as TextAsset;
        Stream s = new MemoryStream(script.bytes);
		reader = new StreamReader (s);
		nextLine = reader.ReadLine ();
		tutorialText.text = nextLine;
		stopReading = false;
	}
	
	void Update () {
		if (!stopReading && numItr > 47) {
			stopReading = true;
		}
		if(Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr < 5){
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			GetComponent<AudioSource>().PlayOneShot(buttonClip, 2.5f);// Plays beep noise.
			numItr++;
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr >= 5 && numItr < 10) { // Makes donuts appear on fifth tap.
			donuts[numItr - 5].gameObject.SetActive(true);
			GetComponent<AudioSource>().PlayOneShot(donutAppear, 0.1f); //Plays donut appear sound for each donut.
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			numItr++;
		}
		if (Input.GetKeyDown (KeyCode.Space) && !stopReading && (numItr >= 10 && numItr <= 47) ) {
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			GetComponent<AudioSource>().PlayOneShot(buttonClip, 2.5f);// Plays beep noise.
			numItr++;
		}
		if (Input.GetKeyDown (KeyCode.Space) && !stopReading && numItr == 17) {
			for(int i = 0; i < 5; i++){
				donuts[i].gameObject.SetActive(false);
			}
			handler.GenerateInstruction(new Vector3(-170f, 120f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-100f, 50f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-30f, -20f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			GetComponent<AudioSource>().PlayOneShot(donutAppear, 0.1f); //Plays donut appear sound.
			text1.gameObject.SetActive(true);
			numItr++;
		}
		if(Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 20){
			handler.DisplayHazard (1, 2, 2, 1);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 25) {
			arrow.gameObject.SetActive(true);
			handler.ResolveHazard (1, 2, 2, 1);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 26) {
			arrow.gameObject.SetActive(false);
			text1.gameObject.SetActive(false);
			handler.ClearAllInstructions();
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 28) {
			handler.GenerateInstruction(new Vector3(-170f, 120f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-100f, 50f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-30f, -20f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			text2.gameObject.SetActive(true);
		}
		if(Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 29){
			handler.DisplayHazard (1, 2, 1, 0);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 34) {
			predictor.gameObject.SetActive(true);
			predictor2.gameObject.SetActive(true);
			handler.ResolveHazard (1, 2, 1, 0);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 35) {
			predictor.gameObject.SetActive (false);
			predictor2.gameObject.SetActive(false);
			text2.gameObject.SetActive(false);
			handler.ClearAllInstructions();
		}
		if(Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 37){
			handler.GenerateInstruction(new Vector3(-170f, 120f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-100f, 50f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			handler.GenerateInstruction(new Vector3(-30f, -20f, 0), new Vector3(0.5f, 0.5f, 0.5f));
			text3.gameObject.SetActive(true);
		}
		if(Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 39){
			handler.DisplayHazard (0, 2, 3, 1);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 42) {
			hardware.gameObject.SetActive(true);
			handler.ResolveHazard (0, 2, 3, 1);
		}
		if (Input.GetKeyDown(KeyCode.Space) && !stopReading && numItr == 45) {
			hardware.gameObject.SetActive(false);
			text3.gameObject.SetActive(false);
			handler.ClearAllInstructions();
		}
	}
}
