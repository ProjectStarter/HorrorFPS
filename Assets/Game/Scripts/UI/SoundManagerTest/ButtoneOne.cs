using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtoneOne : MonoBehaviour {

	void Awake()
	{
		SoundManager.SetVolumeMusic (0.1f);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			float volume = SoundManager.GetVolumeMusic();
			SoundManager.SetVolumeMusic(volume + 0.05f);
		}

		if(Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			float volume = SoundManager.GetVolumeMusic();
			SoundManager.SetVolumeMusic(volume - 0.05f);
		}

		if(Input.GetKeyDown(KeyCode.Plus))
		{
			float volume = SoundManager.GetVolumeSFX();
			SoundManager.SetVolumeMusic(volume + 0.05f);
		}

		if(Input.GetKeyDown(KeyCode.Minus))
		{
			float volume = SoundManager.GetVolumeSFX();
			SoundManager.SetVolumeMusic(volume - 0.05f);
		}
	}

	public void OnClickButtonOne()
	{
		Application.LoadLevel ("test1");
	}

	public void OnClickLaughOne()
	{
		SoundManager.PlayCappedSFX ("laugh1", "LaughSFX");
	}

	public void OnClickLaughtTwo()
	{
		SoundManager.PlayCappedSFX ("laugh2", "LaughSFX");
	}

	public void OnClickRandomLaugh()
	{
		int rand = Random.Range (0,2);

		if (rand == 0)
		{
			SoundManager.PlayCappedSFX("laugh1", "LaughSFX");
		}

		else
		{
			SoundManager.PlayCappedSFX("laugh2", "LaughSFX");
		}
	}

	public void OnClickThunderOne()
	{
		SoundManager.PlayCappedSFX ("Thunder1", "ThunderSFX");
	}
	
	public void OnClickThundertTwo()
	{
		SoundManager.PlayCappedSFX ("Thunder2", "ThunderSFX");
	}
	
	public void OnClickRandomThunder()
	{
		int rand = Random.Range (0,2);
		
		if (rand == 0)
		{
			SoundManager.PlayCappedSFX("Thunder1", "ThunderSFX");
		}
		
		else
		{
			SoundManager.PlayCappedSFX("Thunder2", "ThunderSFX");
		}
	}

	public void CallRainAmbiance()
	{
		SoundManager.PlaySFX ("RainAmbiance", true);
	}

	public void StopRainAmbiance()
	{
		//List<AudioSource> audioSource = new List<AudioSource> ();
		AudioSource[] audioSource;
		GameObject go = null;
		audioSource = SoundManager.Instance.gameObject.GetComponentsInChildren<AudioSource>();
		//audioSource.AddRange(SoundManager.Instance.gameObject.GetComponentsInChildren<AudioSource> ());

		foreach(AudioSource aSource in audioSource)
		{
			Debug.Log(aSource.name);
			if (aSource.name.Contains("RainAmbiance"))
			{
				go = aSource.gameObject;
				continue;
			}
		}
		SoundManager.StopSFXObject (go);
		go = null;
		DestroyImmediate (go);
	}
}
