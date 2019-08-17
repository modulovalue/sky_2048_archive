using UnityEngine;
using System.Collections;

public class AcceScript : MonoBehaviour {
	float speed = 90f;
	public Quaternion rotation = Quaternion.identity;
	public float testvar;
	public Vector3 ace;

	void FixedUpdate () 
	{
		ace = new Vector3(Input.acceleration.z, Input.acceleration.y, Input.acceleration.x);
		rotation.eulerAngles = new Vector3(-Input.acceleration.z * speed + testvar, Input.acceleration.y * speed,0);
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);
	}
}
