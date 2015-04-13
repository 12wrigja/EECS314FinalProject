﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TextReader : MonoBehaviour {

	public string scriptAddress;

	public Text tutorialText;
	public Image[] donuts;

	public AudioClip buttonClip;
	public AudioClip donutAppear;

	private int numItr = 0;
	private string nextLine;
	private StreamReader reader;
	private bool stopReading = false;

	void Start () {
		reader = new StreamReader (scriptAddress);
		nextLine = reader.ReadLine ();
		tutorialText.text = nextLine;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !reader.EndOfStream && !stopReading && numItr < 5){
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			GetComponent<AudioSource>().PlayOneShot(buttonClip, 2.5f);// Plays beep noise.
			numItr++;
		}
		if (Input.GetKeyDown(KeyCode.Space) && !reader.EndOfStream && numItr >= 5) { // Makes donuts appear on fifth tap.
			nextLine = reader.ReadLine();
			tutorialText.text = nextLine;
			donuts[numItr - 5].gameObject.SetActive(true);
			GetComponent<AudioSource>().PlayOneShot(donutAppear, 0.1f); //Plays donut appear sound for each donut.
			numItr++;
		}
		if (!stopReading && reader.EndOfStream) {
			reader.Close ();
			stopReading = true;
		}
	}
}
