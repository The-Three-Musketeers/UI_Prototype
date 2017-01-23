using UnityEngine;
using System;
using System.Collections;
using ArduinoNet;

//This script listens for keys and sends out signals to control
//the game state appropriately.

public class KeyListener : MonoBehaviour {

    //System state variables for UI
    public static bool clicked = false;
    public static bool fuel_selected = false;
    public static bool angle_selected = false;

    //Serial initialization
    public static Serial serial = new Serial("COM3");

    // Update is called once per frame
    //The controls are as follows:
    //Q - Quit the Application
    //Left Arrow - Go to the previous screen in the sequence
    //A - Left option button
    //D - Right option button
    //S - Select option button
    //F - Hold to select the fuel on the gameplay screen
    //G - Hold to select the angle on the gameplay screen
    //Up Arrow - See 'Manual_Slider.cs' for details
    //Down Arrow - Ditto

    void Start() {
        serial.Connect();
        serial.OnButtonPressed += Serial_OnButtonPressed;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (Application.loadedLevel != 0) {
                Application.LoadLevel(Application.loadedLevel - 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            Selector.prev_option();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            Selector.next_option();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            GameState.click();
        }
        else {
            GameState.unclick();
        }
        if (Input.GetKey(KeyCode.F)) {
            GameState.select_fuel();
        }
        else {
            GameState.unselect_fuel();
        }
        if (Input.GetKey(KeyCode.G)) {
            GameState.select_angle();
        }
        else {
            GameState.unselect_angle();
        }
    }

    private void Serial_OnButtonPressed(object sender, ArduinoEventArg arg)
    {
        UnityMainThreadDispatcher.Instance().Enqueue(() => Application.LoadLevel(Application.loadedLevel - 1));
    }
}

