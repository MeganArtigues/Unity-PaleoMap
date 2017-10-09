using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Class to take a screenshot of the current scene

public class Screenshot : MonoBehaviour {
	public InputField mainInputField;
	private InputField name;

//---------------------------------------------------------------------------------------------
	// Check to ensure input field has content
	void LockInput(InputField input)
	{
		if (input.text.Length > 0)
		{
			Debug.Log(input.text + " has been entered");
			this.name = input;//if there was input, assign the variable for later
		}
		else if (input.text.Length == 0)
		{
			Debug.Log("Main Input Empty");
		}
	}

//---------------------------------------------------------------------------------------------
	public void Start()
	{
		//Listener to determine when there is input in the text box - calls LockInput() to check this
		mainInputField.onEndEdit.AddListener(delegate {LockInput(mainInputField); });
	}

//---------------------------------------------------------------------------------------------
	public void captureClick() {
		//saves the screenshot to a location on my computer with the input name as a png file by a factor resolution of 8
		Application.CaptureScreenshot("C:\\Users\\Megan\\Desktop\\UnityScreenshotTest\\" + Keyboard.input + ".png", 8);
	}
}