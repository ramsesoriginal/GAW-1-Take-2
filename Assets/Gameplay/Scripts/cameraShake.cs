using UnityEngine;
using System.Collections;
public class cameraShake : MonoBehaviour
{
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay_start;
	public float shake_intensity_start;
	private float shake_decay;
	private float shake_intensity;

	
	void Update (){
		if (shake_intensity > 0.001f){
			Camera.main.transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			Camera.main.transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Crate") {
			Shake ();
		}
	}
	
	public void Shake(){
		originPosition = Camera.main.transform.position;
		originRotation = Camera.main.transform.rotation;
		shake_decay = shake_decay_start;
		shake_intensity = shake_intensity_start;
	}
}