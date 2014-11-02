using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

	public float time = 1;
	
	// Update is called once per frame
	void OnCollisionEnter () {
		Invoke ("SelfDestrcut", time);
	}

	public void SelfDestrcut() {
		Destroy (gameObject);
	}

}
