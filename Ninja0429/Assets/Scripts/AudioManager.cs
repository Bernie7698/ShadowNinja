using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager _instance;
	private AudioSource Awordaudio;
	public AudioClip AwordAudioClip;

	void Awake(){
		_instance = this;
		Awordaudio = GetComponent<AudioSource> ();
	}
	public void PlayAwordSound(){
		Awordaudio.PlayOneShot (AwordAudioClip);
	}
}
