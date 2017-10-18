using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscReceiveHandler : MonoBehaviour {

	public OSC osc;


	// Use this for initialization
	void Start () {
		osc.SetAddressHandler( "/size/BAS" , OnReceiveBAS );
	}

	// Update is called once per frame
	void Update () {

	}

	void OnReceiveBAS(OscMessage message){
		float size = message.GetFloat(0);
		Debug.Log(size);	
	}
}