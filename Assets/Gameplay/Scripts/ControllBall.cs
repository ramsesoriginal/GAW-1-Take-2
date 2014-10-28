using UnityEngine;
using System.Collections;

public class ControllBall : MonoBehaviour {

	public float speed;
	public float jumpstrength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		rigidbody.AddForce (Vector3.right * h * speed + Vector3.up * v * jumpstrength);
	}
}
