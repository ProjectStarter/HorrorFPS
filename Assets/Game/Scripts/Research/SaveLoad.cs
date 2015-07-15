using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO; // input output
using System.Runtime.Serialization.Formatters.Binary; // this is needed for serialization

public class SaveLoad {
	[SerializeField] private int health;

	private static SaveLoad instance = null;

	public static SaveLoad Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new SaveLoad();
			}
			return instance;
		}
	}

	public int Health
	{
		get { return health; }
		set { this.health = value; }
	}

	void Awake()
	{

	}

	public void Save()
	{
		// this always creates a new file and overwrites everything
		// for release, save must check if file exists.
		// if it exists, open, add/modify, save.
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.Health = this.health;

		binaryFormatter.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = (PlayerData) binaryFormatter.Deserialize(file);
			file.Close();

			this.health = data.Health;
		}

		else
		{
			Debug.LogError("NO FILE TO LOAD.");
		}
	}
}

[Serializable]
class PlayerData
{
	private int health;

	public int Health
	{
		get { return this.health; }
		set { this.health = value; }
	}
}
