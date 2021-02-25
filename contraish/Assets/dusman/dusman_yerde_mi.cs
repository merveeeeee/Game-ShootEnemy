using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_yerde_mi : MonoBehaviour {
	public LayerMask layer;
	public dusman_hareket dino_hareket;
	public Transform dino_transform;
	// Use this for initialization
	void Start () {
		dino_transform = transform.parent;
		dino_hareket = dino_transform.GetComponent <dusman_hareket> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, 0.3f, layer);
		if(hit.collider==null){
			dino_transform.localScale = new Vector3(dino_transform.localScale.x* -1,dino_transform.localScale.y,dino_transform.localScale.z);
			dino_hareket.dusman_hızı *= -1;
		}
	}
}
