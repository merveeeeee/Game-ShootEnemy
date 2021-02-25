using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi_hareket : MonoBehaviour {
	float mermi_hizi = 3f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate (){
		transform.position += new Vector3 (mermi_hizi*Time.deltaTime,0,0);
	}
	public void mermi_sola (){
		mermi_hizi *= -1;
	}
}
