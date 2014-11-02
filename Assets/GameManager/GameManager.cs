using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public enum Levels {
		Menu,
		Options,
		Game,
		Level1,
		Level2,
		Level3,
		Level4,
		Level5,
		Level6,
		GameOver
	};

	public Levels initialLevel;

	public ScoreKeeper scoreKeeper {
		get {
			return GetComponent<ScoreKeeper>();
		}
	}

	public GuiDisabler guiDisabler {
		get {
			return GetComponent<GuiDisabler>();
		}
	}
	
	public SoundEffects soundEffects {
		get {
			return GetComponent<SoundEffects>();
		}
	}

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
		guiDisabler.InitialInit ();
		GameManager.manager = this;
		LoadLevel (initialLevel);
	}
	
	public void SceneInit() {
		scoreKeeper.StartLevel ();
		guiDisabler.Init ();
		Time.timeScale = 1;
	}

}
