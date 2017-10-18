using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicianResponder : MonoBehaviour
{
	private Material m;
	public OSC osc;
	Rigidbody my_collider;
	private float OrbitSpeed = 100.0f;
	public bool receiver=false;
	private Vector3 coord;
	public enum swirl
	{
		nothing,
		left,
		right}

	;

	public swirl sw = swirl.nothing;
	//ControllerGrabObject ctrlObject;
	// Use this for initialization
	void Start ()
	{
		my_collider = GetComponent<Rigidbody> ();
		m = gameObject.GetComponent<Renderer> ().material;
		if (receiver){
			coord = new Vector3 (0f, 0f, 0f);
			Debug.Log("/pos/"+my_collider.name.ToString());

			osc.SetAddressHandler ("/pos/"+my_collider.name.ToString(), OnReceiveBAS);
		}
		//ctrlObject = new ControllerGrabObject ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (sw) {
		case swirl.left:
			Debug.Log ("thrown left!");
			transform.RotateAround (Vector3.zero, Vector3.up, OrbitSpeed * Time.deltaTime);
			sw = swirl.nothing;
			break;
		case swirl.right:
			Debug.Log ("thrown right!");
			transform.RotateAround (Vector3.zero, Vector3.down, OrbitSpeed * Time.deltaTime);
			sw = swirl.nothing;
			break;
		case swirl.nothing:
			break;
		default:
			break;
		}
		if (receiver) {
		// we  place the object based on the X,Y,Z coordinates received from OSC messages
			my_collider.transform.position=coord;
		}
		if (!receiver) {
			Debug.Log ("not receiver");
			float pullForce = 100f;
			Vector3 forceDirection = transform.position - my_collider.transform.position;
			my_collider.AddForce(forceDirection.normalized * pullForce * Time.deltaTime);
			sendMsg (my_collider);
		}
	}

	

	public void sendMsg (Rigidbody my_collider)
	{
		OscMessage message = new OscMessage ();

		message.address = "/sound/" + my_collider.gameObject.name.ToString (); // "BA", "DJ", ...
		message.values.Add (my_collider.transform.position.x);
		message.values.Add (my_collider.transform.position.y);
		message.values.Add (my_collider.transform.position.z);
		//Debug.Log("OSC Message: " + message);
		osc.Send (message);
	}


	void OnReceiveBAS (OscMessage message)
	{
		coord = new Vector3(message.GetFloat(0), message.GetFloat(1), message.GetFloat(2));
		Debug.Log (my_collider.name.ToString()+" "+coord.ToString());	
	}


}
