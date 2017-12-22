using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBuster : MonoBehaviour {
	// Use this for initialization
	void Start () {
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
		if(this.gameObject.transform.position.y < -600)
		{
			destroyThis();
		}
	}
	
	public void destroyThis()
	{
		Destroy(this.gameObject);
	}
	
	
}