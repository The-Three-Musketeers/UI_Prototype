using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manual_Click : MonoBehaviour {

	public static string name = "Button";
	
	// Update is called once per frame
	void Update () {
		if (KeyListener.clicked) {
			GameObject.Find (name).GetComponent<Button> ().onClick.Invoke ();
			reset ();
		}
	}

	public static void set_name (string new_name) {
		name = new_name;
	}

	public static void reset () {
		name = "Button";
		Selector.reset ();
	}
}
