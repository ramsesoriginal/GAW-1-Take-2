using UnityEngine;
using System.Collections;

public class ResetHighscores : MonoBehaviour {

	// Use this for initialization
	public void Reset () {
		PlayerPrefs.DeleteAll ();
	}

}
