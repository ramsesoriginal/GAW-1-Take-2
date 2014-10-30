﻿using UnityEngine;
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
	public float StartBestTime {
		get {
			return startBestTime;
		}
	}
	public bool AllDone {
		get {
			return !running || currentCrates == maxCrates;
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
	private float startBestTime;
	private float startTime;
	public bool running;

	public void CollectCrate() {
		currentCrates++;
	}

	public static float MaxHighscore() {
		var maxHighscore = 6000.0f;
		if (GameManager.manager.CurrentLevel == GameManager.Levels.Level1)
			maxHighscore = 10;
		if (GameManager.manager.CurrentLevel == GameManager.Levels.Level2)
			maxHighscore = 60;
		if (GameManager.manager.CurrentLevel == GameManager.Levels.Level3)
			maxHighscore = 200;
		return maxHighscore;
	}

	public void StartLevel() {
		maxCrates = GameObject.FindGameObjectsWithTag("Crate").Length;
		currentCrates = 0;
		startBestTime = bestTime = PlayerPrefs.GetFloat(HighscoreName,MaxHighscore());
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
				bestTime = PlayerPrefs.GetFloat(HighscoreName,MaxHighscore());
				running = false;
				Time.timeScale = 0.1f;
			}
		}
	}
}
