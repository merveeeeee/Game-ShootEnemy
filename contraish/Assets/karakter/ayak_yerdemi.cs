using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ayak_yerdemi : MonoBehaviour {

	public LayerMask katman;
	public static bool yerde = false;
	public float ziplamagucu;
	public Rigidbody2D rigit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position,Vector2.down,0.35f,katman);
		if (hit.collider != null) {
			yerde = true;
		} 
		else {
			yerde = false;
		}
		
		if (Input.GetKeyDown (KeyCode.Space) && yerde) {
			rigit.velocity += new Vector2 (karakter_script.horizont, ziplamagucu);
			
		} else if (Input.GetKeyDown (KeyCode.W) && yerde) {
			rigit.velocity += new Vector2 (karakter_script.horizont, ziplamagucu);
		}




	}
	void FixedUpdate(){

	}


}
