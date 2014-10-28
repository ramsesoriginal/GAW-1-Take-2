using UnityEngine;
using System.Collections;

public class LocalScoreProxy : MonoBehaviour {

	public int CurrentCrates;
	public string CurrentCratesDisplay;
	public UnityEngine.UI.Text CurrentCratesText;
	public int MaxCrates;
	public string MaxCratesDisplay;
	public UnityEngine.UI.Text MaxCratesText;
	public float CurrentTime;
	public string CurrentTimeDisplay;
	public UnityEngine.UI.Text CurrentTimeText;
	public float BestTime;
	public string BestTimeDisplay;
	public UnityEngine.UI.Text BestTimeText;
	public bool Running;
	public bool CurrentLevelDone;
	public float CurrentLevelHighscore;
	public string CurrentLevelHighscoreDisplay;
	public UnityEngine.UI.Text CurrentLevelHighscoreText;
	public string levelName;
	public UnityEngine.UI.Text LevelNameText;
	public GameObject EnableWhenDone;

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
		if (CurrentCratesText != null)
			CurrentCratesText.text = CurrentCratesDisplay;
		MaxCrates = score.MaxCrates;
		MaxCratesDisplay = MaxCrates.ToString (cratesString);
		if (MaxCratesText != null)
			MaxCratesText.text = MaxCratesDisplay;
		CurrentTime = score.CurrentTime;
		CurrentTimeDisplay = CurrentTime.ToString (timeString);
		if (CurrentTimeText != null)
			CurrentTimeText.text = CurrentTimeDisplay;
		BestTime = score.BestTime;
		BestTimeDisplay = BestTime.ToString (timeString);
		if (BestTimeText != null)
			BestTimeText.text = BestTimeDisplay;
		Running = !score.AllDone;
		CurrentLevelDone = getHighScore () != null;
		CurrentLevelHighscore = CurrentLevelDone ? (float)getHighScore () : 9999;
		CurrentLevelHighscoreDisplay = CurrentLevelDone ? ((float)getHighScore ()).ToString(timeString) : "---";
		if (CurrentLevelHighscoreText != null)
			CurrentLevelHighscoreText.text = CurrentLevelHighscoreDisplay;
		if (LevelNameText != null)
			LevelNameText.text = levelName;
		if (Running) {
			if (EnableWhenDone != null)
				EnableWhenDone.SetActive (false);
		} else {
			if (EnableWhenDone != null)
				EnableWhenDone.SetActive (true);
		}
	}


	private float? getHighScore() {
		float? score = null;
		if (string.IsNullOrEmpty(levelName))
			levelName = GameManager.manager.CurrentLevel.ToString ("G");
		if (PlayerPrefs.GetInt ("BestTime-" + levelName + "Done", 0) == 1) {
			score = PlayerPrefs.GetFloat("BestTime-" + levelName,6000);
		}
		return score;
	}
}
