using UnityEngine;
using System.Collections;

public class LoadScenes : MonoBehaviour {

	public GameManager.Levels level;

	public void LoadSelectedLevel() {
		GameManager.manager.LoadLevel(level);
	}

	public void LoadOptions () {
		GameManager.manager.LoadLevel(GameManager.Levels.Options);
	}

	public void ReloadCurrent () {
		GameManager.manager.LoadLevel(GameManager.manager.CurrentLevel,true);
	}
	
	public void LoadGame () {
		GameManager.manager.LoadLevel(GameManager.Levels.Game);
	}
	
	public void LoadMenu () {
		GameManager.manager.LoadLevel(GameManager.Levels.Menu);
	}
	
	public void CloseGame () {
		Application.Quit();
	}
}
