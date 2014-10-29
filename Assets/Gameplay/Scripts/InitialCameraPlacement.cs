using UnityEngine;
using System.Collections;

public class InitialCameraPlacement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("MainCamera").transform.position = transform.position;
		GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation = transform.rotation;
	}
}
