using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {
	public Transform camera;
	// Use this for initialization
	void Start () {
		camera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
			if(this.gameObject.transform.position.y < -300)
			{
				destroyThis();
			}
	}
	
	public void destroyThis()
	{
		Destroy(this.gameObject);
	}
}
