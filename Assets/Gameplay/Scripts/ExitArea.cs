using UnityEngine;
using System.Collections;

public class ExitArea : MonoBehaviour {
	
	public GameObject[] EnableWhenLost;
	public GameObject[] DisableWhenLost;

	private static bool lost;
	private bool wasAlive;
	// Use this for initialization
	void Start () {
		lost = false;
		wasAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		var done = GameManager.manager.scoreKeeper.AllDone;
		if (!done) {
			foreach (var c in EnableWhenLost)
				c.SetActive (lost);
			foreach (var c in DisableWhenLost)
				c.SetActive (!lost);
			if (lost)
			{
				if (wasAlive) 
				{
					wasAlive = false;
					GameManager.manager.soundEffects.PlayLoose();
				}
				Time.timeScale = 0.1f;
				GameManager.manager.scoreKeeper.running = false;
			}
		}
	}

	void OnTriggerEnter() {
		lost = true;
	}
}
