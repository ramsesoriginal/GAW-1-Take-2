using UnityEngine;
using System.Collections;

public class MoveCameraHere : MonoBehaviour {

	public Transform target;
	public float speed = 0.1f;

	private static float distance;
	private static Vector3 p;
	private static Quaternion r;
	private static Transform _target;
	private static float _laststartTime;
	private float laststartTime;

	void OnTriggerEnter () {
		_target = target;
		laststartTime = _laststartTime = Time.time;
		StartCoroutine("Move");
	}

	IEnumerator Move() {
		distance = (transform.position - _target.position).magnitude;
		p = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
		r = GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation;
		for (float f = 0; f < distance && laststartTime == _laststartTime; f += speed) {
			GameObject.FindGameObjectWithTag ("MainCamera").transform.position = Vector3.Lerp(p,_target.position,f/distance);
			GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation = Quaternion.Lerp(r,_target.rotation,f/distance); 
			yield return null;
		}
		/*if (laststartTime == _laststartTime) {
			GameObject.FindGameObjectWithTag ("MainCamera").transform.position = _target.position;
			GameObject.FindGameObjectWithTag ("MainCamera").transform.rotation = _target.rotation;
		}*/
	}

}
