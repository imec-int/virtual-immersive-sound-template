using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicianResponder : MonoBehaviour {
	private Material m;
	public OSC osc;
	Rigidbody my_collider;
	//ControllerGrabObject ctrlObject;
	// Use this for initialization
	void Start () {
		my_collider = GetComponent<Rigidbody> ();
		m = gameObject.GetComponent<Renderer> ().material;
		//ctrlObject = new ControllerGrabObject ();
	}
	
	// Update is called once per frame
	void Update () {
		sendMsg (my_collider);
	}



	public void sendMsg(Rigidbody my_collider){
		OscMessage message = new OscMessage ();

		message.address = "/sound/" + my_collider.gameObject.name.Substring (0,2); // "BA", "DJ", ...
		message.values.Add(my_collider.transform.position.x);
		message.values.Add(my_collider.transform.position.y);
		message.values.Add(my_collider.transform.position.z);
		Debug.Log("OSC Message: " + message);
		osc.Send(message);
	}
}
