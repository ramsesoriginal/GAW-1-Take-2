using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public int CurrentCrates {
		get {
			return currentCrates;
		}
	}
	public int MaxCrates {
		get {
			return maxCrates;
		}
	}
	public float CurrentTime {
		get {
			return currentTime;
		}
	}
	public float BestTime {
		get {
			return bestTime;
		}
	}
	public bool AllDone {
		get {
			return currentCrates == maxCrates;
		}
	}

	private string HighscoreName {
		get {
			return "BestTime-" + GameManager.manager.CurrentLevel.ToString("G");
		}
	}

	private int currentCrates;
	private int maxCrates;
	private float currentTime;
	private float bestTime;
	private float startTime;
	private bool running;

	public void CollectCrate() {
		currentCrates++;
	}

	public void StartLevel() {
		maxCrates = GameObject.FindGameObjectsWithTag("Crate").Length;
		currentCrates = 0;
		bestTime = PlayerPrefs.GetFloat(HighscoreName,6000);
		running = true;
		currentTime = startTime = Time.time;
	}

	void Update() {
		if (running) {
			currentTime = Time.time - startTime;
			if (AllDone ) {
				if ( currentTime < bestTime) {
					PlayerPrefs.SetFloat (HighscoreName, currentTime);
					PlayerPrefs.SetInt (HighscoreName+"Done", 1);
				}
				bestTime = PlayerPrefs.GetFloat(HighscoreName,6000);
				running = false;
				Time.timeScale = 0.1f;
			}
		}
	}
}
