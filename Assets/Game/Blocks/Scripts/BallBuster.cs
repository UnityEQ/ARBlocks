using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBuster : MonoBehaviour {
	public float ballToCam;
	public Vector3 camPos;
	// Use this for initialization
	void Start () {
		//Vector3 screenSpaceCenter = new Vector3(0.5f,0.5f,0);
		//Vector3 shootEnd = Camera.main.ViewportToWorldPoint(screenSpaceCenter);
		this.GetComponent<Rigidbody> ().AddForce(transform.forward * 90f);
		camPos = Camera.main.transform.position;
	}
	
	void OnCollisionEnter(Collision col){
		blockHealthBehavior thisBlockHealth;

		if (col.transform.gameObject.GetComponent<blockHealthBehavior> () != null){
			thisBlockHealth = col.transform.gameObject.GetComponent<blockHealthBehavior> ();
//			GetComponent<AudioSource> ().Play ();
			thisBlockHealth.health = 0;
			thisBlockHealth.Explode ();
			destroyThis();
			//thisBlockHealth.health--;
		}
	}
	// Update is called once per frame
	void Update () {
		ballToCam = Vector3.Distance(camPos, this.transform.position);
		if(ballToCam > 30)
		{
			destroyThis();
		}
	}
	
	public void destroyThis()
	{
		Destroy(this.gameObject);
	}
	
	
}