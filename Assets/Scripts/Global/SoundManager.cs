using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private bool isMute = false;

	[Header("Audio Sources")]
	public AudioSource soundEffects;

	[Header("BG Clips")]
	public AudioClip menuBG;
	public AudioClip gameBG;

	[Header("Sound Clips")]
	public AudioClip buttonPress;

	public void Mute(){

		isMute = true;
		AudioListener.volume = 0;
	}

	public void UnMute(){
	
		isMute = false;
		AudioListener.volume = 1;
    }

	public void Pause(){

		this.soundEffects.Pause ();
	}

	public void UnPause(){

		this.soundEffects.UnPause ();
	}

    public void PlaySound(AudioClip _clip){

		soundEffects.PlayOneShot (_clip);
	}

	public void Stop_PlayingSound(){
		soundEffects.Stop ();
	}
}
