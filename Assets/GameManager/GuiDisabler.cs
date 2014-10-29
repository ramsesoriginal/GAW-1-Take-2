using UnityEngine;
using System.Collections;

public class GuiDisabler : MonoBehaviour {

	private bool GuiDisabled;

	public void Toggle() {
		GuiDisabled = ! GuiDisabled;
	}
	
	public void Init() {
		foreach (var g in GameObject.FindGameObjectsWithTag ("UI"))
			g.SetActive (!GuiDisabled);
	}
	
	public void InitialInit() {
		GuiDisabled = false;
	}
}
