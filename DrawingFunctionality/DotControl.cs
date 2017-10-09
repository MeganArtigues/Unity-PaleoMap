using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//Class to delete drawn objects on the screen

public class DotControl : MonoBehaviour{
	public static bool canErase;//only allows erasing if eraser is chosen

//---------------------------------------------------------------------------------------------
	void Start(){
		GetComponent<SpriteRenderer> ().color = Paint.color;
	}

//---------------------------------------------------------------------------------------------
	//delete object instance being touchced
	public void OnMouseOver(){
		if (canErase) {
			if (Paint.toolType == "eraser") {
				Destroy (gameObject);
			}
		}
	}

//---------------------------------------------------------------------------------------------
	//clear all instances on the screen
	public static void clearAll(GameObject [] allDots, GameObject [] allTriangles){
		foreach (GameObject a in allDots) {
			Destroy (a);
		}
		foreach (GameObject t in allTriangles) {
			Destroy (t);
		}

		//reset instances of the drawing object forms
		Paint.baseDot = (GameObject)(Resources.Load ("DrawingPrefabs/Dot"));
		Paint.leftTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/leftTriangle"));
		Paint.rightTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/rightTriangle"));
		Paint.upTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/upTriangle"));
		Paint.downTriangle = (GameObject)(Resources.Load ("DrawingPrefabs/downTriangle"));
		Paint.currentObject = Paint.baseDot;
	}
}