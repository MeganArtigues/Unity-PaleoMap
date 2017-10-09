using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//class to alter the transparency of a panel and its content

public class Transparent : MonoBehaviour {

	Image img;
	Image panel;
	Slider slider;
	public string mapName;
	public string sliderName;
	public string panelName;

//---------------------------------------------------------------------------------------------
	//get the image and panel that transparency needs to affect
	//get the slider for value
	void Awake(){
		img = GameObject.Find(mapName).GetComponent <Image>();
		panel = GameObject.Find(panelName).GetComponent <Image>();
		slider = GameObject.Find(sliderName).GetComponent <Slider>();

	}
		
//---------------------------------------------------------------------------------------------
	public void changeTransparent(){
		Color t= img.color;//get the color
		t.a=slider.value;//set alpha to slider value
		img.color = t;//set that new alpha value to the color

		Color z= panel.color;//get the color
		z.a=slider.value;//set alpha to slider value
		panel.color = z;//set that new alpha value to the color
	}
}
