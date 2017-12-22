using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PinController : MonoBehaviour {
	public Mapbox.Utils.Vector2d originPos;
	public AbstractMap Map;
	
	public string prefabName;
	public string name;
	public double lat;
	public double lon;
	public double height;
	public int material;
	public float hp;
	public float blockY;
	
	public GameObject outerColor;
	public Renderer rendPin;
	public Renderer rendBlock;
	public GameObject block;

	// Use this for initialization
	void Start () {

			rendPin = outerColor.GetComponent<Renderer>();
			rendBlock = block.GetComponent<Renderer>();
			block.transform.position = new Vector3(block.transform.position.x,blockY,block.transform.position.z);
	}
	
	void OnMouseDown()
	{
		rendPin.material.color = Color.green;
		rendBlock.material.color = Color.green;
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
