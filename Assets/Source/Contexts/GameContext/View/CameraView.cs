using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class CameraView : View {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float x = 0;
	    float z = 0;
	    if (Input.GetKey(KeyCode.W))
	        z++;
        else if (Input.GetKey(KeyCode.S))
            z--;

	    if (Input.GetKey(KeyCode.A))
	        x++;
        else if (Input.GetKey(KeyCode.D))
            x--;

        transform.position += new Vector3(x, 0, z);
	}
}
