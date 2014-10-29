using UnityEngine;
using System.Collections;

public class ToggleUi : MonoBehaviour {

	public void Toggle() {
		GameManager.manager.guiDisabler.Toggle ();
	}
}
