using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//Class to clap gametag to location to label a map of the world

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	public static int correctTags;
	public Draggable.Slots typeOfItem = Draggable.Slots.OPTIONS;

//---------------------------------------------------------------------------------------------
	void Start(){
		//counter for a functionality that pops up additional educational content when all tags placed correctly
		correctTags = 0;
	}

//---------------------------------------------------------------------------------------------
	//methods not used, but Unity requires them 
	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log ("OnPointerEnter");
	}

	public void OnPointerExit(PointerEventData eventData) {
		//Debug.Log ("OnPointerExit");
	}

//---------------------------------------------------------------------------------------------
	public void OnDrop(PointerEventData eventData) {
		//if the tag wass placed correctly, clamp it to that spot and disable dragging functionality
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			if (typeOfItem == d.typeOfItem){// || typeOfItem == Draggable.Slots.OPTIONS) {
				d.parentToReturnTo = this.transform;
				this.transform.SetSiblingIndex (5);
				d.isDraggable = false;
				correctTags++;
			}
		}
	}
}
