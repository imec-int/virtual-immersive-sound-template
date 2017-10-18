using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour
{
//	public float pullRadius = 4f;
	public float pullForce = 0.4f;
	public GameObject attractedTo;

	// Use this for initialization
	void Start ()
	{
		
	}
	//	void FixedUpdate(){
	//		foreach(Collider collider in Physics.OverlapSphere(transform.position, pullRadius){
	//			Vector3 forceDirection = transform.position - collider.transform.position;
	//			collider.rigidbody.AddForce()
	//		}
	//
	//	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 direction = attractedTo.transform.position - transform.position;
		if (!gameObject.GetComponent<MusicianResponder> ().receiver) {
			gameObject.GetComponent<Rigidbody> ().AddForce (pullForce * direction);
		}
	}
}
