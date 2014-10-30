using UnityEngine;
using System.Collections;

public class LocalScoreProxy : MonoBehaviour {

	public int CurrentCrates;
	public string CurrentCratesDisplay;
	public UnityEngine.UI.Text[] CurrentCratesText;
	public int MaxCrates;
	public string MaxCratesDisplay;
	public UnityEngine.UI.Text[] MaxCratesText;
	public float CurrentTime;
	public string CurrentTimeDisplay;
	public UnityEngine.UI.Text[] CurrentTimeText;
	public float BestTime;
	public string BestTimeDisplay;
	public UnityEngine.UI.Text[] BestTimeText;
	public float StartBestTime;
	public string StartBestTimeDisplay;
	public UnityEngine.UI.Text[] StartBestTimeText;
	public bool NewBestTime;
	public GameObject[] EnableWhenNewBestTime;
	public bool Running;
	public bool CurrentLevelDone;
	public GameObject[] EnableWhenAlreadyDone;
	public float CurrentLevelHighscore;
	public string CurrentLevelHighscoreDisplay;
	public UnityEngine.UI.Text[] CurrentLevelHighscoreText;
	public string levelName;
	public UnityEngine.UI.Text[] LevelNameText;
	public GameObject[] EnableWhenDone;

	// Use this for initialization
	void Start () {
		UpdateFields ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateFields ();
	}

	private string cratesString = "#00";
	private string timeString = "#0000.00";

	private void UpdateFields() {
		var score = GameManager.manager.scoreKeeper;
		CurrentCrates = score.CurrentCrates;
		CurrentCratesDisplay = CurrentCrates.ToString (cratesString);
		foreach (var c in CurrentCratesText)
			c.text = CurrentCratesDisplay;
		MaxCrates = score.MaxCrates;
		MaxCratesDisplay = MaxCrates.ToString (cratesString);
		foreach (var c in MaxCratesText)
			c.text = MaxCratesDisplay;
		CurrentTime = score.CurrentTime;
		CurrentTimeDisplay = CurrentTime.ToString (timeString);
		foreach (var c in CurrentTimeText)
			c.text = CurrentTimeDisplay;
		BestTime = score.BestTime;
		BestTimeDisplay = BestTime.ToString (timeString);
		foreach (var c in BestTimeText)
			c.text = BestTimeDisplay;
		StartBestTime = score.StartBestTime;
		StartBestTimeDisplay = StartBestTime.ToString (timeString);
		foreach (var c in StartBestTimeText)
			c.text = StartBestTimeDisplay;
		if (BestTime != StartBestTime)
			NewBestTime = true;
		else
			NewBestTime = false;
		Running = !score.AllDone;
		CurrentLevelDone = getHighScore () != null;
		CurrentLevelHighscore = CurrentLevelDone ? (float)getHighScore () : 9999;
		CurrentLevelHighscoreDisplay = CurrentLevelDone ? ((float)getHighScore ()).ToString(timeString) : "---";
		foreach (var c in CurrentLevelHighscoreText)
			c.text = CurrentLevelHighscoreDisplay;
		foreach (var c in LevelNameText)
			c.text = levelName;
		if (Running) {
			foreach (var c in EnableWhenDone)
				c.SetActive (false);
		} else {
			foreach (var c in EnableWhenDone)
				c.SetActive (true);
		}
		if (CurrentLevelDone) {
			foreach (var c in EnableWhenAlreadyDone)
				c.SetActive (true);
		} else {
			foreach (var c in EnableWhenAlreadyDone)
				c.SetActive (false);
		}
		if (NewBestTime) {
			foreach (var c in EnableWhenNewBestTime)
				c.SetActive (true);
		} else {
			foreach (var c in EnableWhenNewBestTime)
				c.SetActive (false);
		}
	}


	private float? getHighScore() {
		float? score = null;
		if (string.IsNullOrEmpty(levelName))
			levelName = GameManager.manager.CurrentLevel.ToString ("G");
		if (PlayerPrefs.GetInt ("BestTime-" + levelName + "Done", 0) == 1) {
			score = PlayerPrefs.GetFloat("BestTime-" + levelName,ScoreKeeper.MaxHighscore());
		}
		return score;
	}
}
