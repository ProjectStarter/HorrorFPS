using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	[SerializeField] private Button healthUp;
	[SerializeField] private Button healthDown;
	[SerializeField] private Text healthLabel;

	void Awake()
	{
		this.Load ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHealthUpButtonClick()
	{
		SaveLoad.Instance.Health += 10;
		this.healthLabel.text = "Health: " + SaveLoad.Instance.Health;
	}

	public void OnHealthDownButtonClick()
	{
		SaveLoad.Instance.Health -= 10;
		this.healthLabel.text = "Health: " + SaveLoad.Instance.Health;
	}

	public void Save()
	{
		SaveLoad.Instance.Save ();
	}

	public void Load()
	{
		SaveLoad.Instance.Load ();
		this.healthLabel.text = "Health: " + SaveLoad.Instance.Health;
	}

	public void GoToScene1()
	{
		Application.LoadLevelAsync ("SaveLoadScene_One");
	}

	public void GoToScene2()
	{
		Application.LoadLevelAsync ("SaveLoadScene_Two");
	}
}
