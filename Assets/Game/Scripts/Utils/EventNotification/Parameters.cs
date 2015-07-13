using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Parameters {

	//basic non-numerical data
	private Dictionary<string, char> charDictData;
	private Dictionary<string, string> stringDictData;

	//basic numerical data
	private Dictionary<string, int> intDictData;
	private Dictionary<string, float> floatDictData;
	private Dictionary<string, double> doubleDictData;
	private Dictionary<string, short> shortDictData;
	private Dictionary<string, long> longDictData;

	//basic boolean data
	private Dictionary<string, bool> boolDictData;

	//array data
	private Dictionary<string, ArrayList> arrayListDictData;

	//object data
	private Dictionary<string, object> objectDictData;

	//gameobject data
	private Dictionary<string, GameObject> gameObjectDictData;

	public Parameters()
	{
		Debug.Log ("Parameters Initialized.");

		this.charDictData = new Dictionary<string, char> ();
		this.stringDictData = new Dictionary<string, string> ();

		this.intDictData = new Dictionary<string, int> ();
		this.floatDictData = new Dictionary<string, float> ();
		this.doubleDictData = new Dictionary<string, double> ();
		this.shortDictData = new Dictionary<string, short> ();
		this.longDictData = new Dictionary<string, long> ();

		this.boolDictData = new Dictionary<string, bool> ();

		this.arrayListDictData = new Dictionary<string, ArrayList> ();

		this.objectDictData = new Dictionary<string, object> ();

		this.gameObjectDictData = new Dictionary<string, GameObject> ();
	}

	public void PutExtra(string paramName, char value)
	{
		this.charDictData.Add(paramName,value);
	}

	public void PutExtra(string paramName, string value)
	{
		this.stringDictData.Add (paramName, value);
	}

	public void PutExtra(string paramName, int value)
	{
		this.intDictData.Add (paramName, value);
	}

	public void PutExtra(string paramName, float value)
	{
		this.floatDictData.Add (paramName, value);
	}

	public void PutExtra(string paramName, double value)
	{
		this.doubleDictData.Add (paramName, value);
	}

	public void PutExtra(string paramName, short value)
	{
		this.shortDictData.Add (paramName, value);
	}

	public void PutExtra(string paramName, long value)
	{
		this.longDictData.Add (paramName, value);
	}

	public void PutExtra(string paramName, bool value)
	{
		this.boolDictData.Add (paramName, value);
	}
	
	public void PutExtra(string paramName, object obj)
	{
		this.objectDictData.Add (paramName, obj);
	}

	public void PutExtra(string paramName, GameObject gObj)
	{
		this.gameObjectDictData.Add (paramName, gObj);
	}

	public void PutExtra(string paramName, ArrayList arrayList)
	{
		this.arrayListDictData.Add (paramName, arrayList);
	}

	public void PutExtra(string paramName, object[] objArray)
	{
		ArrayList arrayList = new ArrayList ();
		arrayList.AddRange (objArray);
		this.PutExtra (paramName, arrayList);
	}

	public void PutExtra(string paramName, GameObject[] gObjArray)
	{
		ArrayList arrayList = new ArrayList ();
		arrayList.AddRange (gObjArray);
		this.PutExtra (paramName, arrayList);
	}

	public char GetCharExtra(string paramName, char defaultValue)
	{
		if (this.charDictData.ContainsKey(paramName))
		{
			return this.charDictData[paramName];
		}

		else
		{
			return defaultValue;
		}
	}

	public string GetStringExtra(string paramName, string defaultValue)
	{
		if (this.stringDictData.ContainsKey(paramName))
		{
			return this.stringDictData[paramName];
		}
		
		else
		{
			return defaultValue;
		}
	}

	public int GetIntExtra(string paramName, int defaultValue)
	{
		if (this.intDictData.ContainsKey(paramName))
		{
			return this.intDictData[paramName];
		}
		
		else
		{
			return defaultValue;
		}
	}

	public float GetFloatExtra(string paramName, float defaultValue)
	{
		if (this.floatDictData.ContainsKey(paramName))
		{
			return this.floatDictData[paramName];
		}

		else
		{
			return defaultValue;
		}
	}

	public double GetDoubleExtra(string paramName, double defaultValue)
	{
		if (this.doubleDictData.ContainsKey(paramName))
		{
			return	this.doubleDictData[paramName];
		}

		else
		{
			return defaultValue;
		}
	}

	public short GetShortExtra(string paramName, short defaultValue)
	{
		if (this.shortDictData.ContainsKey(paramName))
		{
			return this.shortDictData[paramName];
		}
		
		else
		{
			return defaultValue;
		}
	}

	public long GetLongExtra(string paramName, long defaultValue)
	{
		if (this.longDictData.ContainsKey(paramName))
		{
			return this.longDictData[paramName];
		}
		
		else
		{
			return defaultValue;
		}
	}

	public bool GetBoolExtra(string paramName, bool defaultValue)
	{
		if (this.boolDictData.ContainsKey(paramName))
		{
			return this.boolDictData[paramName];
		}
		
		else
		{
			return defaultValue;
		}
	}

	public object GetObjectExtra(string paramName)
	{
		if (this.objectDictData.ContainsKey(paramName))
		{
			return this.objectDictData[paramName];
		}
		
		else
		{
			return null;
		}
	}
	
	public GameObject GetGameObjectExtra(string paramName)
	{
		if (this.gameObjectDictData.ContainsKey(paramName))
		{
			return this.gameObjectDictData[paramName];
		}
		
		else
		{
			return null;
		}
	}

	public ArrayList GetArrayListExtra(string paramName)
	{
		if (this.arrayListDictData.ContainsKey(paramName))
		{
			return this.arrayListDictData[paramName];
		}

		else
		{
			return null;
		}
	}

	public object[] GetObjectArrayExtra(string paramName)
	{
		ArrayList arrayListData = this.GetArrayListExtra (paramName);

		if(arrayListData != null)
		{
			return arrayListData.ToArray();
		}

		else
		{
			return null;
		}
	}

	public GameObject[] GetGameObjectArrayExtra(string paramName)
	{
		ArrayList arrayListData = this.GetArrayListExtra (paramName);
		
		if(arrayListData != null)
		{

			return arrayListData.ToArray() as GameObject[];
		}
		
		else
		{
			return null;
		}
	}
}
