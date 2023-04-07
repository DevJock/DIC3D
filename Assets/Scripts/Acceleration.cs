using UnityEngine;
using System.Collections;

public class Acceleration : MonoBehaviour 
{

	public float multiplier;

	void Update () 
	{
		float x = Input.acceleration.x;
		float y = Input.acceleration.y;
		float z = Input.acceleration.z;
		Vector3 forceVector = new Vector3 (x, y, z);
		gameObject.GetComponent<Rigidbody>().AddForce(forceVector,ForceMode.Acceleration);
	}
}
