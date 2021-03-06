using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This script acts in a similar fashion to the KeyListener, but only repsonds to
//Up and Down Arrows when the F or G buttons are held. Its purpose is to control
//the sliders on the gameplay screen manually, without the need for a mouse.

public class Manual_Slider : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        //Don't do any of this if the rocket is in launch mode
        if (RocketBehavior.launch == false)
        {
            float curr = 0.0f;
            //If the F button is currently being held, listen and respond appropriately
            if (GameState.fuel_selected)
            {
                curr = GameObject.Find("Fuel Slider").GetComponent<Slider>().value;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    increase(curr, "Fuel Slider");
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    decrease(curr, "Fuel Slider");
                }
            }
            //If the G button is currently being held, listen and respond appropriately
            if (GameState.angle_selected)
            {
                curr = GameObject.Find("Angle Slider").GetComponent<Slider>().value;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    increase(curr, "Angle Slider");
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    decrease(curr, "Angle Slider");
                }
            }
        }
	}

	void increase(float curr, string component) {
		float new_value = curr + 0.0025f;
		if (new_value > 1) {
			new_value = 1f;
		}
		GameObject.Find (component).GetComponent<Slider> ().value = new_value;
	}

	void decrease(float curr, string component) {
		float new_value = curr - 0.0025f;
		if (new_value < 0) {
			new_value = 0f;
		}
		GameObject.Find (component).GetComponent<Slider> ().value = new_value;
	}
}
