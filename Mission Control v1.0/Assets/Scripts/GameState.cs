using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static string mission;
	public static string rocket_color;

	public string get_mission() {
		return mission;
	}

	public void set_mission(string new_mission) {
		mission = new_mission;
	}

	public string get_rocket_color() {
		return rocket_color;
	}

	public void set_rocket_color(string new_rocket_color) {
		rocket_color = new_rocket_color;
	}

}
