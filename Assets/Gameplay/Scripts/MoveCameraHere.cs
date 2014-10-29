using UnityEngine;
using System.Collections;

public class MoveCameraHere : MonoBehaviour {

	public Transform target;
	public float speed = 0.1f;

	void OnTriggerEnter () {
		StartCoroutine("Move");
	}

	IEnumerator Move() {
		var distance = (transform.position - target.position).magnitude;
		var p = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
		var r = GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation;
		for (float f = 0; f < distance; f += 0.1f) {
			GameObject.FindGameObjectWithTag ("MainCamera").transform.position = Vector3.Lerp(p,target.position,f/distance);
			GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation = Quaternion.Lerp(r,target.rotation,f/distance); 
			yield return null;
		}
		GameObject.FindGameObjectWithTag ("MainCamera").transform.position = target.position;
		GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation = target.rotation;
	}

}
