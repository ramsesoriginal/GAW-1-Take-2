using UnityEngine;
using System.Collections;

public class CrateCollector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Crate") {
			Destroy (other.gameObject);
			GameManager.manager.scoreKeeper.CollectCrate ();
		}
	}
}
