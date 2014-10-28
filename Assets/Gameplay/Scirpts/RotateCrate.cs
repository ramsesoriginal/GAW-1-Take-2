using UnityEngine;
using System.Collections;

public class RotateCrate : MonoBehaviour {

	public float rotateSpeed = 5;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
	}
}
