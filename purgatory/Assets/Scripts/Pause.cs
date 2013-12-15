using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public float savedTimeScale;
	
	public void TogglePause() {
		if (IsPaused()) {
			UnpauseGame();
		} else {
			PauseGame();
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			TogglePause();
		}
	}

	void PauseGame() 
	{
    	savedTimeScale = Time.timeScale;
    	Time.timeScale = 0;
    	AudioListener.pause = true;		
	}
	
	void UnpauseGame() {
		Time.timeScale = savedTimeScale;
    	AudioListener.pause = false;	
	}
	
	public bool IsPaused() {
		return 0 == Time.timeScale;
	}

	void OnGUI() {
		if (IsPaused()) {
			GUI.Box(new Rect (0,0,100,50), "Paused");
		}
	}
}
