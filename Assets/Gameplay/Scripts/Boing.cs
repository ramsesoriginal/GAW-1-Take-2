using UnityEngine;
using System.Collections;
using System.Linq;

public class Boing : MonoBehaviour {

	// Use this for initialization
	void OnCollisionExit (Collision collisionInfo) {
		if (collisionInfo.contacts.Any (q => q.otherCollider.gameObject.tag != "BG")) {
			GameManager.manager.soundEffects.PlayBoing ();
			Debug.Log ("boing");
		}
	}

}
