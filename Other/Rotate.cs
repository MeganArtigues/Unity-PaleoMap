using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Class to rotate sphere by touch and mouse

public class Rotate : MonoBehaviour {
	public GameObject sphere;
	float rotationSpeed = 5.0f;//mouse-triggered rotation speed
	float touchRotationSpeed = 10.0f;//touch triggered rotation speed
	public static bool rotate; //is the sphere allowed to rotate

	//Used to depermine double tap to reset sphere to original orientation
	int tapCount;
	float doubleTapTimer;


//---------------------------------------------------------------------------------------------
	//allow rotating on start of program
	void Awake(){
		rotate = true;
		tapCount = 0;
	}

//---------------------------------------------------------------------------------------------
	void Update (){
		//if rotation is allowed, continuously rotate without input
		if (rotate == true) {
			sphere.transform.Rotate (Vector3.down, rotationSpeed * Time.deltaTime);
		}

		//if the sphere is touched
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();
			if (Input.GetMouseButton (0)) {
				if (Physics.Raycast (ray, out hit)) {
					//Debug.Log(hit.collider.name);
				}
			}

		//if hit was on the shere and is not on a UI object
		if (hit.collider == sphere.GetComponent<Collider> () && !EventSystem.current.IsPointerOverGameObject ()) {
			//get the touch input
			if (Input.touchCount == 1) {
				Touch touch0 = Input.GetTouch (0);//get the point touched
				float rotX = Input.touches [0].deltaPosition.x * Mathf.Deg2Rad;//convert the x coordinate to radians
				float rotY = Input.touches [0].deltaPosition.y * Mathf.Deg2Rad;//convert the y coordinate to radians

				
				//apply rotation along X and Y plane
				if (touch0.phase == TouchPhase.Moved) {
					sphere.transform.RotateAround (Vector3.up, -rotX/touchRotationSpeed);
					sphere.transform.RotateAround (Vector3.right, rotY/touchRotationSpeed);
				}
			}


			//if 2 fingers are used, get those touches - pivot around one stationary finger
			if (Input.touchCount == 2) {
				Touch touch0 = Input.GetTouch (0);//get the point touched
				Touch touch1 = Input.GetTouch (1);//get the point touched
				float rotX = Input.touches [1].deltaPosition.x * Mathf.Deg2Rad;//convert the x coordinate to radians
				float rotY = Input.touches [1].deltaPosition.y * Mathf.Deg2Rad;//convert the y coordinate to radians


				//apply rotation - only on z axis
				if (touch1.phase == TouchPhase.Moved) {
					sphere.transform.RotateAround (Vector3.forward, -rotX/touchRotationSpeed);
					sphere.transform.RotateAround (Vector3.forward, rotY/touchRotationSpeed);
			
				}
			}
				
			//determine double tap to resent orientation
			if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				tapCount++;
			}
			if (tapCount > 0) //if there is one touch, start the timer
			{
				doubleTapTimer += Time.deltaTime;
			}
			if (tapCount >= 2)//if there is a second touch
			{
				if (doubleTapTimer > 0.5f) {//if the touches occured too far apart, don't reset
					doubleTapTimer = 0f;
					tapCount = 0;
				} else {//otherwise reset the orientation
					sphere.transform.rotation = Quaternion.identity; 
					doubleTapTimer = 0.0f;
					tapCount = 0;
				}
			}
		}
	}

//---------------------------------------------------------------------------------------------
//performed only if in unity editor with no touch-interaction
#if UNITY_EDITOR
	public void OnMouseDrag(){
		if (!EventSystem.current.IsPointerOverGameObject()){
			float rotX; 
			float rotY;
				
			rotY = Input.GetAxis ("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;	
			rotX = Input.GetAxis ("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
				
			sphere.transform.RotateAround (Vector3.up, -rotX);
			sphere.transform.RotateAround (Vector3.right, rotY);
		}
	}
#endif

	//changed rotation ability based on play/pause button in MainMenu
	public void PlayPause(){
		rotate = !rotate;
	}

}
