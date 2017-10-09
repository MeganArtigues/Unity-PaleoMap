using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Class to rotate a panel object alongg the z-axis

public class RotatePanel : MonoBehaviour, IPointerDownHandler, IDragHandler {
	float touchRotationSpeed = 10.0f;

	private Vector3 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;

	//variables to reset to original orientation
	int tapCount;
	float doubleTapTimer;


//---------------------------------------------------------------------------------------------
	//initialize the panel that will rotate
	void Awake(){
		tapCount = 0;
		Canvas canvas = GetComponentInParent<Canvas> ();
		if (canvas != null){
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform.parent as RectTransform;
		}
	}

//---------------------------------------------------------------------------------------------
	//get the panel to transform when finger/mouse is clicked down on it
	public void OnPointerDown (PointerEventData data){
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToWorldPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
	}

//---------------------------------------------------------------------------------------------
	public void OnDrag(PointerEventData data){
		if (Input.touchCount == 2) {
			Touch touch0 = Input.GetTouch (0);//get the point touched
			Touch touch1 = Input.GetTouch (1);//get the point touched
			float rotX = Input.touches [1].deltaPosition.x * Mathf.Deg2Rad;//convert the x coordinate to radians
			float rotY = Input.touches [1].deltaPosition.y * Mathf.Deg2Rad;//convert the y coordinate to radians

			//apply rotation - only on z axis
			if (touch1.phase == TouchPhase.Moved) {
				panelRectTransform.transform.RotateAround (Vector3.forward, -rotX/touchRotationSpeed);
				panelRectTransform.transform.RotateAround (Vector3.forward, rotY/touchRotationSpeed);
			}
		}
	}

//---------------------------------------------------------------------------------------------
	//reset orientation of panel on double-tap request
	void Update(){
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			tapCount++;
		}
		if (tapCount > 0)
		{
			doubleTapTimer += Time.deltaTime;
		}
		if (tapCount >= 2)
		{
			if (doubleTapTimer > 0.5f) {
				doubleTapTimer = 0f;
				tapCount = 0;
			} else {
				panelRectTransform.transform.rotation = Quaternion.identity; 
				doubleTapTimer = 0.0f;
				tapCount = 0;
			}
		}
	}
}