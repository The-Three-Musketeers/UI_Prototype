using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {
	
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
	}
}
