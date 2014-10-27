using UnityEngine;
using System.Collections;

public class GameInitializer : MonoBehaviour {

	public GameObject gameManagerPrefab;
	private GameObject gameManagerInstantiated;
	public GameManager gameManager {
		get {
			return gameManagerInstantiated.GetComponent<GameManager>();
		}
	}
	public GameObject gameManagerObject {
		get {
			return gameManagerInstantiated;
		}
	}

	// Called before Start, even if not enabled. Initialisations.
	void Awake () {
		gameManagerInstantiated = GameObject.FindGameObjectWithTag ("GameController");
		if (gameManagerInstantiated==null) {
			gameManagerInstantiated = (GameObject)Instantiate (gameManagerPrefab, transform.position, transform.rotation);
			gameManagerInstantiated.name = gameManagerPrefab.name;
			gameManager.InitialInit();
		}
		gameManager.SceneInit ();
	}

	// Called before Update, only if enabled
	void Start() {
	}
}
