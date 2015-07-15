using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashScript : MonoBehaviour {

	[SerializeField] private Image splashImage;
	private bool isLoadMainMenu = false;
	private const float delayInSeconds = 2.0f;

	// Use this for initialization
	void Start () {
		splashImage.color = new Color (1f, 1f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (splashImage.color.a <= 1.0f)
		{
			splashImage.color = new Color (1f, 1f, 1f, splashImage.color.a + (Time.deltaTime*0.25f));
		}

		if (!isLoadMainMenu && splashImage.color.a >= 1.0f)
		{
			isLoadMainMenu = true;
			StartCoroutine(DelayFunction(delayInSeconds));
		}
	}

	private IEnumerator DelayFunction(float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		Application.LoadLevelAsync (SceneName.MAINMENU_SCENE_NAME);
	}
}
