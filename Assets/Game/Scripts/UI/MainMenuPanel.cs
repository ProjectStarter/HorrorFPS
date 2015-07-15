using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour {

	[SerializeField] private Button playButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayButtonClick()
	{
		Application.LoadLevelAsync (SceneName.GAME_SCENE_NAME);
	}
}
