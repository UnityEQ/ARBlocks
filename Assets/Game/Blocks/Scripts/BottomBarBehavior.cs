using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Examples;

namespace UnityEngine.XR.iOS
{
	public class BottomBarBehavior : MonoBehaviour {

		public Transform Weapon, Diamond, Ball, Block4x4;
		public GameObject m_ballPrefab;
		public FocusSquare focusSquare;
		//public PlacePins placePins;
		public PositionWithLocationProvider locationProvider;
		public GameObject mainCam;	
		public GameObject PickAxeParent;

		public AxeControl axeControl;

		//public GameObject areaParent;
		
		private Vector3 moveUp = new Vector3 (0, 8f, 0);
		private Vector3 scaleUp = new Vector3 (.1f, .1f, 0);
		
		
		public GameObject DiamondOre;
		public GameObject Stack4x4x4;
		public enum Selected {Weapon, Diamond, Ball, Block4x4};
		public static Selected currentSelected; 
		public static int blockPlaceType = 0;

		void Start(){
			//debug 
			//placePins.PinPlacer();
			
			ResetButtons ();
			ButtonPressed (Weapon);
			PickAxeParent.SetActive (true);
			currentSelected = Selected.Weapon;
			//BlocksHitTest.currentScale = new Vector3 (1, 1, 1);
		}

		private void ResetButtons(){
			//reset all other buttons
			foreach (Transform child in this.transform) {
				if (child.localScale.x > 1.01f) {
					child.localPosition -= moveUp;
					child.localScale -= scaleUp;
					PickAxeParent.SetActive (false);
				}
			}
		}
		
		public void ReticleClicked()
		{
			
		}

		public void WeaponButtonDown(){

			if (currentSelected == Selected.Weapon) {
				axeControl.UseWeapon ();
			} else {
				//focusSquare.trackingInitialized = false;
				focusSquare.foundSquare.SetActive(false);
				focusSquare.findingSquare.SetActive(false);
				focusSquare.SquareState = FocusSquare.FocusState.Initializing;
				ResetButtons ();
				ButtonPressed (Weapon);
				PickAxeParent.SetActive (true);
				currentSelected = Selected.Weapon;
			}
		}

		public void DiamondButtonDown(){
			
			if (currentSelected == Selected.Diamond) {
				if(focusSquare.foundSquare.activeSelf){
					Vector3 tempV = new Vector3(0f,0f,8.4f);
					//gamesparks api
					//GameObject newBlock = Instantiate (DiamondOre, focusSquare.foundSquare.transform.position, focusSquare.foundSquare.transform.rotation);
//					placePins.PinPlacer(focusSquare.foundSquare.transform.position,focusSquare.foundSquare.transform.rotation,focusSquare.foundSquare.transform.localPosition.y);
					//PinPlacer(Vector3 pos, Vector3 rot, float cursorY)
					BlocksSpawner.Instance.SaveMessage ("test",focusSquare.foundSquare.transform.localPosition.y,locationProvider.latlon.x, locationProvider.latlon.y,Input.location.lastData.altitude,1,1);
					BlocksSpawner.Instance.CleanPool(true);
				}
			} else {
				//focusSquare.trackingInitialized = true;
				focusSquare.SquareState = FocusSquare.FocusState.Finding;
				ResetButtons ();
				ButtonPressed (Diamond);
				currentSelected = Selected.Diamond;
			}
		}
		
		public void Block4x4ButtonDown(){
			
			if (currentSelected == Selected.Block4x4) {
				if(focusSquare.foundSquare.activeSelf){GameObject newBlock = Instantiate (Stack4x4x4, focusSquare.foundSquare.transform.position, focusSquare.foundSquare.transform.rotation);}
			} else {
				//focusSquare.trackingInitialized = true;
				focusSquare.SquareState = FocusSquare.FocusState.Finding;
				ResetButtons ();
				ButtonPressed (Block4x4);
				currentSelected = Selected.Block4x4;
			}
		}
		
		public void BallButtonDown(){

			if (currentSelected == Selected.Ball) {
				ShootBall();
			} else {
				//focusSquare.trackingInitialized = false;
				focusSquare.foundSquare.SetActive(false);
				focusSquare.findingSquare.SetActive(false);
				focusSquare.SquareState = FocusSquare.FocusState.Initializing;
				ResetButtons ();
				ButtonPressed (Ball);
				currentSelected = Selected.Ball;
			}
		}


		void ButtonPressed(Transform desiredTransform){
			//scale buttons to show when they are selected
			desiredTransform.localPosition += moveUp;
			desiredTransform.localScale += scaleUp;
			desiredTransform.SetAsLastSibling ();
		}

		public void ShootBall()
		{
			var cameraTransform = mainCam.transform;
			var ball = GameObject.Instantiate (m_ballPrefab, cameraTransform.position, Quaternion.identity);
			ball.GetComponentInChildren<Rigidbody> ().AddForce (cameraTransform.forward * 500.0f);
			//ball.AddComponent<BallDestroy>();
			ball.AddComponent<BallBuster>();
		}
	}
}
