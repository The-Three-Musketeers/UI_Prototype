using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manual_Slider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float curr = 0.0f;
		if (KeyListener.fuel_selected) {
			curr = GameObject.Find ("Fuel Slider").GetComponent<Slider> ().value;
			if (Input.GetKey(KeyCode.UpArrow)) {
				increase (curr, "Fuel Slider");
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				decrease (curr, "Fuel Slider");
			}
		}
		if (KeyListener.angle_selected) {
			curr = GameObject.Find ("Angle Slider").GetComponent<Slider> ().value;
			if (Input.GetKey(KeyCode.UpArrow)) {
				increase (curr, "Angle Slider");
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				decrease (curr, "Angle Slider");
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
