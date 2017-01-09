using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {

	public static bool clicked = false;
	public static bool fuel_selected = false;
	public static bool angle_selected = true;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)){
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (Application.loadedLevel != 0) {
                Application.LoadLevel(Application.loadedLevel - 1);
            }
        }
		if (Input.GetKeyDown(KeyCode.A)){
			Selector.prev_option();
		}
		if (Input.GetKeyDown(KeyCode.D)){
			Selector.next_option();
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			clicked = true;
		} else {
			clicked = false;
		}
		if (Input.GetKey(KeyCode.F)) {
			fuel_selected = true;
		} else {
			fuel_selected = false;
		}
		if (Input.GetKey(KeyCode.G)) {
			angle_selected = true;
		} else {
			angle_selected = false;
		}
	}
}
