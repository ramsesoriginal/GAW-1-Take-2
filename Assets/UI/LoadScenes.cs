using UnityEngine;
using System.Collections;

public class LoadScenes : MonoBehaviour {

	public void LoadOptions () {
		GameManager.manager.LoadLevel(GameManager.Levels.Options);
	}
	
	public void LoadGame () {
		GameManager.manager.LoadLevel(GameManager.Levels.Game);
	}
	
	public void LoadMenu () {
		GameManager.manager.LoadLevel(GameManager.Levels.Menu);
	}
}
