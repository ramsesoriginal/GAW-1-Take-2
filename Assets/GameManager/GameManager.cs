using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public enum Levels {
		Menu,
		Options,
		Game,
		Level1
	};

	public Levels initialLevel;

	public Levels CurrentLevel {
		get {
			return (Levels) System.Enum.Parse(typeof(Levels), Application.loadedLevelName);
		}
	}

	public void LoadLevel(Levels level, bool reload = false) {
		if (reload || CurrentLevel != level)
			Application.LoadLevel (level.ToString ("G"));
	}

	public void InitialInit() {
		DontDestroyOnLoad (gameObject);
		LoadLevel (initialLevel);
		GameManager.manager = this;
	}
	
	public void SceneInit() {
	}
}
