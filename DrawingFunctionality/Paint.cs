using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to instantiate objects on the screen to simulate drawing functionality

public class Paint : MonoBehaviour {

	//all the shapes that you can draw with
	public static GameObject baseDot;
	public static GameObject leftTriangle;
	public static GameObject rightTriangle;
	public static GameObject upTriangle;
	public static GameObject downTriangle;
	public static GameObject currentObject;

	public static string toolType;//tool currently being used
	public static Color color; //what color it draws in
	public static bool canDraw; //if drawing is allowed (disabled when panel is closed)
	public static GameObject[] all; //all the dot instances on the screen
	public static int i; //counter for array above


//---------------------------------------------------------------------------------------------
	//load all images for gameobject shape
	void Awake(){
		baseDot = (GameObject)(Resources.Load ("DrawingPrefabs/Dot"));
		leftTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/leftTriangle"));
		rightTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/rightTriangle"));
		upTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/upTriangle"));
		downTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/downTriangle"));
		currentObject = baseDot;
		i = 0;
	}
		
//---------------------------------------------------------------------------------------------
	//initialize first tool used as the pencil = allowed to draw when panel opens
	void Start(){
		toolType = "pencil";
	}

//---------------------------------------------------------------------------------------------
	void Update ()
	{
		if (canDraw) {//if drawing is allowed
			if (Input.touchCount > 0) {
				Vector3 objPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 1));//get the touch position to world view
				if (toolType == "pencil") {//if the tool is pencil, draw

					if (currentObject != baseDot) {//if the object to draw is one of the triangles
						if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
							GameObject newItem = (GameObject)Instantiate (currentObject, objPosition, Quaternion.identity);//instantiate the new object on the screen
							newItem.transform.SetAsLastSibling ();//put it in front of all the others
							all [i] = newItem;//add it to the array
							i++;
						}
					} else {//if it's a simple base dot
						if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved) {
							GameObject newItem = (GameObject)Instantiate (currentObject, objPosition, Quaternion.identity);
							newItem.transform.SetAsLastSibling ();
							all [i] = newItem;
							i++;
						}
					}

				}
			}
		}
	}
}

