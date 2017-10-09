using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

//Class to change the map image by swipe on a panel object
//Acts like a jumbotron

public class ChangeMap : MonoBehaviour {

	public Image img;
	public Text header;//the title of the map
	public Object[] maps;//all map images (90)
	private int counter;

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public static bool allowSwipe;//variable to allow swipe only if touching the proper field

//---------------------------------------------------------------------------------------------
	//initialize all maps
	void Start () {
		maps = Resources.LoadAll ("Paleo-Maps/MapSlideshow", typeof(Sprite));//get all the maps from that folder
		counter = 0;
		img.sprite = (Sprite)(maps [counter]);
		header.text = img.sprite.name;

		allowSwipe = false;
	}

//---------------------------------------------------------------------------------------------
	void Update(){
		if (allowSwipe) {
			if (Input.touches.Length == 1) {
				Touch t = Input.GetTouch (0);
				if (t.phase == TouchPhase.Began) {
					//save began touch 2d point
					firstPressPos = new Vector2 (t.position.x, t.position.y);
				}
				if (t.phase == TouchPhase.Ended) {
					//save ended touch 2d point
					secondPressPos = new Vector2 (t.position.x, t.position.y);

					//create vector from the two points
					currentSwipe = new Vector3 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

					//normalize the 2d vector
					currentSwipe.Normalize ();
		
					//swipe left
					if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						nextImage ();
					}
					//swipe right
					if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
						previousImage ();
					}
				}
			}
		}
	}
			
//---------------------------------------------------------------------------------------------
	void changeMap(){
		
		if ((counter > -1) && (counter < 90)){
			img.sprite = (Sprite)(maps [counter]);
			header.text = img.sprite.name;
		}
	}

//---------------------------------------------------------------------------------------------
	public void nextImage(){
		if (counter < maps.Length -1) {
			this.counter++;
		}
		changeMap ();
	}

//---------------------------------------------------------------------------------------------
	public void previousImage(){
		if (counter > 0) {
			this.counter--;
		}
		changeMap ();
	}

}

