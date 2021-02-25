using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karakter_script : MonoBehaviour {

	public float hareket_hizi;
	public static float horizont;
	public bool ates;
	Animator animasyoncum;
	public float can = 145;
	public Image can_bar;
	RectTransform rect;
	public Transform silahim;
	public GameObject mermi;
	float mermi_sikma_hizi = 0.8f;
	float mermi_sikma_hizi_aktif = 0.5f;

	// Use this for initialization
	void Start () {
		animasyoncum = GetComponent<Animator> ();
		rect = can_bar.rectTransform;
	}
	
	// Update is called once per frame
	void Update () {
		if(mermi_sikma_hizi_aktif>0){
			mermi_sikma_hizi_aktif-= Time.deltaTime;
		}
		rect.sizeDelta = new Vector2 (can, rect.sizeDelta.y);
		if (Input.GetKey (KeyCode.Mouse0)) {
			ates = true;
			if(mermi_sikma_hizi_aktif<=0){
				mermi_sikma_hizi_aktif = mermi_sikma_hizi;
			GameObject go = Instantiate(mermi,silahim.transform.position,new Quaternion());
			if(transform.localScale.x<0){
				go.GetComponent<mermi_hareket>().mermi_sola();
				}
			}
		} else {
			ates = false;
		}
		animasyoncum.SetBool ("ates_ediyorum",ates);
	}
	void FixedUpdate(){
		bool kosuyor = false;
		horizont = Input.GetAxis("Horizontal");
	    transform.position += new Vector3 (horizont * hareket_hizi * Time.deltaTime, 0, 0);

		if(horizont!=0){
			kosuyor=true;
		}
		animasyoncum.SetBool ("kosuyorum",kosuyor);
		yonDuzelt ();
	}
	void yonDuzelt (){
		if(horizont<0){
			transform.localScale = new Vector3(-1,1,1);
		}
		else if(horizont>0){
			transform.localScale = new Vector3(1,1,1);
		}
	}
	void OnTriggerStay2D(Collider2D coll){
		if(coll.tag=="dusman"){
			can --;
		}
	}



}
