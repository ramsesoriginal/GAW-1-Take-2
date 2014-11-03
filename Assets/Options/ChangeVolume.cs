using UnityEngine;
using System.Collections;

public class ChangeVolume : MonoBehaviour {

	public void ChangeVolumeTo() {
		var volume = GetComponentInChildren<UnityEngine.UI.Slider>().value;
		if (GameManager.manager != null) {
			GameManager.manager.soundEffects.GetComponent<AudioSource> ().volume = volume;
			GameManager.manager.soundEffects.PlayBoing ();
			
			PlayerPrefs.SetFloat ("Volume", volume);
		}
	}

	void Start() {
		if (GameManager.manager != null) {
			var volume = GameManager.manager.soundEffects.GetComponent<AudioSource> ().volume;
			GetComponentInChildren<UnityEngine.UI.Slider>().value = volume;
		}
	}

}
