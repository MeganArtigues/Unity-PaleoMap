using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//Class to drag gametags onto a map to label locations

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform parentToReturnTo = null;
	public enum Slots {AFRICA, SOUTHAM, NORTHAM, INDIA, EURASIA, AUSTRALIA, ANTARTICA, OPTIONS, DROPAREA};
	public Slots typeOfItem = Slots.OPTIONS;
	public bool isDraggable = true;

//---------------------------------------------------------------------------------------------
	public void OnBeginDrag(PointerEventData eventData) {
		//Debug.Log ("OnBeginDrag");
		if (isDraggable) {
			parentToReturnTo = this.transform.parent;

			this.transform.SetParent (this.transform.parent.parent);

			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

//---------------------------------------------------------------------------------------------
	public void OnDrag(PointerEventData eventData) {
		//Debug.Log ("OnDrag");
		if (isDraggable) {
			this.transform.position = eventData.position;
		}
	}

//---------------------------------------------------------------------------------------------
	public void OnEndDrag(PointerEventData eventData) {
		//Debug.Log ("OnEndDrag");
		if (isDraggable) {
			transform.SetSiblingIndex (5);
			this.transform.SetParent (parentToReturnTo);	
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
}
