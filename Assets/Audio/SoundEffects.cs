using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

	public AudioClip boing;
	public AudioClip win;
	public AudioClip loose;
	public AudioClip collect;
	public AudioClip destroy;

	private AudioSource player {
		get {
			return GetComponent<AudioSource>();
		}
	}
	
	private void Play(AudioClip clip) {
		player.clip = clip;
		player.Play ();
	}

	public void PlayBoing() {
		Play(boing);
	}
	
	public void PlayWin() {
		Play(win);
	}
	
	public void PlayLoose() {
		Play(loose);
	}
	
	public void PlayCollect() {
		Play(collect);
	}
	
	public void PlayDestroy() {
		Play(destroy);
	}
}
