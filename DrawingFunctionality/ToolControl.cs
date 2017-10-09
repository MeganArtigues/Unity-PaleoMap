using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Communicated with Paint and DotControl to set the drawing tool, object type, and color before drawing occurs

public class ToolControl : MonoBehaviour {

//---------------------------------------------------------------------------------------------
	public void ChangeTool(string toolName){

		if (toolName == "eraser") {
			Paint.toolType = "eraser";
			DotControl.canErase = true;
			Paint.canDraw = false;
		} else if (toolName == "pencil") {
			Paint.toolType = "pencil";
			Paint.currentObject = Paint.baseDot;
			DotControl.canErase = false;
			Paint.canDraw = true;
		} else if (toolName == "colors") {
			Paint.color = GetComponent<Image> ().color;
		} else if (toolName == "leftTriangle") {
			Paint.currentObject = Paint.leftTriangle;
		} else if (toolName == "rightTriangle") {
			Paint.currentObject = Paint.rightTriangle;
		} else if (toolName == "upTriangle") {
			Paint.currentObject = Paint.upTriangle;
		} else if (toolName == "downTriangle") {
			Paint.currentObject = Paint.downTriangle;
		} else if (toolName == "clear") {
			GameObject[] allDots = GameObject.FindGameObjectsWithTag ("Dot");
			GameObject[] allTriangles = GameObject.FindGameObjectsWithTag ("Triangles");
			DotControl.clearAll (allDots, allTriangles);
		}
	}

//---------------------------------------------------------------------------------------------
	public void canDrawFalse(){
		Paint.canDraw = false;
		DotControl.canErase = false;
	}

//---------------------------------------------------------------------------------------------
	public void canDrawTrue(){
		Paint.canDraw = true;
		DotControl.canErase = false;
	}


}
