using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman_hareket : MonoBehaviour {
	public float dusman_hızı;
	public float dusman_kosma_hızı;
	public float current_speed;
	public float görüs_mesafesi;
	public LayerMask layer;
	public Animator animasyoncum;
	public bool gordu_mu;
	bool temasta = false;
	bool oldum_mu = false;
	// Use this for initialization
	void Start () {
		animasyoncum = GetComponent<Animator> ();
		if(transform.localScale.x<0){
			dusman_hızı *= -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		if(oldum_mu){
			return;
		}
		if(temasta==false || gordu_mu == false){
		transform.position += new Vector3 (current_speed*Time.deltaTime,0,0);
		}
		if (gordu_mu) {
			current_speed = dusman_kosma_hızı*dusman_hızı;
		} else {
			current_speed=dusman_hızı;
		}

		animasyoncum.SetBool("goruyor_mu",gordu_mu);
		
		gordu_mu = bizi_goruyor_mu ();
	}
	bool bizi_goruyor_mu()
	{
		Vector2 yon;
		if (transform.localScale.x > 0) {
			yon = Vector2.right;
		} else {
			yon=Vector2.left;
		}
		RaycastHit2D hit = Physics2D.Raycast(transform.position,yon,görüs_mesafesi,layer);
		if(hit.collider == null){
			return false;
		}
		return true;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			temasta=true;
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			temasta=false;
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.tag == "mermi"){
			animasyoncum.SetBool("oldu_mu",true);
			Destroy(coll.gameObject);
			oldum_mu= true;
		}
	}
	void yok_ol(){
		Destroy (gameObject,2f);
	}
}
