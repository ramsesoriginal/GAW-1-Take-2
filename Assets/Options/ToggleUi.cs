using UnityEngine;
using System.Collections;

public class ToggleUi : MonoBehaviour {

	public void Toggle() {
		GameManager.manager.guiDisabler.Toggle ();
	}

	public void Update() {
		if (GameManager.manager.guiDisabler.isActive)
			GetComponentInChildren<UnityEngine.UI.Text>().text = "Disable UI";
		else
			GetComponentInChildren<UnityEngine.UI.Text>().text = "Enable UI";
	}
}
