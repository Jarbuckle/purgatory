using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	
	public GUIStyle levelTitleStyle;
	public GUIStyle textBoxStyle;

	private bool showTextBox = false;
	private string textBoxContent = "";
	
	private bool showLevelTitle = false;
	private string levelTitleContent = "";

	/**
	 * Displays the text box control and overwrites any
	 * previously displayed text with the specified text.
	 */
	public void ShowTextBox(string text) {
		showTextBox = true;
		textBoxContent = text;
	}

	/**
	 * Hides the text box control.
	 */
	public void HideTextBox() {
		showTextBox = false;
		textBoxContent = "";
	}

	/**
	 * Displays the level title control and overwrites any
	 * previously displayed text with the specified text.
	 */
	public void ShowLevelTitle(string title) {
		showLevelTitle = true;
		levelTitleContent = title;
	}

	/**
	 * Hides the level title control.
	 */
	public void HideLevelTitle() {
		showLevelTitle = false;
		levelTitleContent = "";
	}

	void OnGUI() {
		if (showLevelTitle) {
			GUILayout.BeginArea(new Rect((Screen.width - 600)/2, (Screen.height - 100)/2, 600, 200));
			GUILayout.Label (levelTitleContent, levelTitleStyle);
			GUILayout.EndArea();
		}
		if (showTextBox) {
			GUILayout.BeginArea(new Rect((Screen.width - 300)/2, Screen.height - 160, 300, 150));
			GUILayout.Label (textBoxContent, textBoxStyle);
			GUILayout.EndArea();
		}
	}
}
