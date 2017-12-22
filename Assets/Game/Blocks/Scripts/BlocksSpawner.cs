using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Examples;
using GameSparks.Core;

public class BlocksSpawner : MonoBehaviour {

	private static BlocksSpawner _instance;
	public AbstractMap Map;
	public GameObject arCamera;
	public static BlocksSpawner Instance { get { return _instance; } } 
	public PositionWithLocationProvider locationProvider;

	public GameObject messagePrefabAR;

	void Awake(){
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (DelayTestMessage ());
	}

	IEnumerator DelayTestMessage(){

		yield return new WaitForSeconds (5f);
		LoadAllMessages();
		StartCoroutine (PlayerLocation());
//test
		//SavePlayer(11,11);
		//LoadPlayers();
		//SaveMessage ("1", 1.1,1.1,1.1,1,1);
	}
	
	IEnumerator PlayerLocation(){
		while(true) 
		{ 
			Debug.Log ("OnCoroutine: "+(int)Time.time);
			Vector2d test = locationProvider.latlon;
			SavePlayer(test.x,test.y);
			yield return new WaitForSeconds(3f);
		}
	}

	public void RemoveAllMessages(){
		new GameSparks.Api.Requests.LogEventRequest ()
			.SetEventKey ("REMOVE_MESSAGES")
			.Send ((response) => {
			if (!response.HasErrors) {
				Debug.Log ("Message Saved To GameSparks...");
			} else {
				Debug.Log ("Error Saving Message Data...");
			}
		});
	}

	public void LoadAllMessages(){
		List<GameObject> messageObjectList = new List<GameObject> ();
		
		new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LOAD_BLOCKS").Send((response) => {
			if (!response.HasErrors) {
				Debug.Log("Received Player Data From GameSparks...");
				List<GSData> locations = response.ScriptData.GetGSDataList ("all_Blocks");
				for (var e = locations.GetEnumerator (); e.MoveNext ();) {
					var name = e.Current.GetString ("name");
					var lat = double.Parse(e.Current.GetString ("lat"));
					var lon = double.Parse(e.Current.GetString ("lon"));
					var height = double.Parse(e.Current.GetString ("height"));
					var material = int.Parse(e.Current.GetString ("material"));
					var hp = float.Parse(e.Current.GetString ("hp"));
					var blockY = float.Parse(e.Current.GetString ("blockY"));
					
					GameObjectPool.instance.GetObjectForType("Pin",Map,name,lat,lon,height,material,hp,blockY);
					//GameObjectPool.instance.GetObjectForType("Stack1x1x1",Map,name,lat,lon,height,material,hp,blockY);
//old					
//					var llpos = new Vector2d(lat, lon);
//					var pos = Conversions.GeoToWorldPosition(llpos, Map.CenterMercator, Map.WorldRelativeScale);					
//					placePins.Coordinates.Add(new Vector3((float)pos.x,blockY,(float)pos.y));
//					
//					Vector2d mapRefPoint = new Vector2d (arCamera.transform.position.x, arCamera.transform.position.z);
//					var pos2 = Conversions.GeoToWorldPosition(llpos, mapRefPoint, Map.WorldRelativeScale);					
//					placePins.CoordinatesB.Add(new Vector3((float)pos.x,blockY,(float)pos.y));
				}
//				placePins.LoadPins();
			} else {
				Debug.Log("Error Loading Message Data...");
			}
		});
	}
	
	public void LoadPlayers(){		
		new GameSparks.Api.Requests.LogEventRequest()
		
		.SetEventKey("NEAR_ME")
		.SetEventAttribute ("MAX_DIST", 100)
		.SetEventAttribute ("SINCE", 15)
		.Send((response) => {
			
			if (!response.HasErrors) {
				Debug.Log("R2eceived Player Data From GameSparks...");
				List<GSData> locations = response.ScriptData.GetGSDataList ("data");
				for (var e = locations.GetEnumerator (); e.MoveNext ();) {
					Debug.Log("hj");
				}
			} else {
				Debug.Log("Error Loading Message Data...");
			}
		});
	}
	
	public void SavePlayer(double latx, double lony) {
		Debug.Log("LATY : " + latx);
		new GameSparks.Api.Requests.LogEventRequest ()

			.SetEventKey ("STORE_LOC")
			.SetEventAttribute ("LON", lony.ToString())
			.SetEventAttribute ("LAT", latx.ToString())
			.Send ((response) => {
				
			if (!response.HasErrors) {
				Debug.Log ("Saved player location to database");
			} else {
				Debug.Log ("Error Saving Message Data...");
			}
		});
	}

	public void SaveMessage(string name,float cursorY,double lat, double lon, float alt, int type, int health){
		new GameSparks.Api.Requests.LogEventRequest ()

			.SetEventKey ("SAVE_BLOCKS")
			.SetEventAttribute ("name", name)
			//.SetEventAttribute ("blockX", lat.ToString())
			.SetEventAttribute ("blockY", cursorY.ToString())
			//.SetEventAttribute ("blockZ", lat.ToString())
			.SetEventAttribute ("lat", lat.ToString())
			.SetEventAttribute ("lon", lon.ToString())
			.SetEventAttribute ("height", alt.ToString())
			.SetEventAttribute ("material", type.ToString())
			.SetEventAttribute ("hp", health.ToString())
			.Send ((response) => {
				
			if (!response.HasErrors) {
				Debug.Log ("Message Saved To GameSparks...");
			} else {
				Debug.Log ("Error Saving Message Data...");
			}
		});
	}
	
		public void CleanPool(bool reset)
		{
            GameObject temp = null;
			
			//temp = GameObjectPool.instance.spawnlist.FirstOrDefault(obj => obj.name == spawn_id.ToString());
            if (GameObjectPool.instance)
            {
                if (GameObjectPool.instance.spawnlist.Count != 0)
                {
					while (GameObjectPool.instance.spawnlist.Count != 0)
					{
					    temp = GameObjectPool.instance.spawnlist.First();
					    string PrefabName = temp.GetComponent<PinController>().prefabName;
						
					    temp.name = PrefabName;
					    GameObjectPool.instance.PoolObject(temp);
					    GameObjectPool.instance.spawnlist.Remove(temp);
					}
                }
            }
			if(reset){LoadAllMessages();}
		}
}