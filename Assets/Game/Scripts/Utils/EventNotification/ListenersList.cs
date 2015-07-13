using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListenersList
{
	private List<System.Action<Parameters>> eventListeners;
	public List<System.Action<Parameters>> EventListeners
	{
		get { return eventListeners; }
	}

	private List<System.Action> eventListenersNoParams;
	public List<System.Action> EventListenersNoParams
	{
		get { return eventListenersNoParams; }
	}

	public ListenersList ()
	{
		this.eventListeners = new List<System.Action<Parameters>>();
		this.eventListenersNoParams = new List<System.Action>();
	}

	public void AddListener (System.Action<Parameters> action)
	{
		this.eventListeners.Add (action);
	}

	public void AddListener (System.Action action)
	{
		this.eventListenersNoParams.Add (action);
	}

	public void RemoveListener (System.Action<Parameters> action)
	{
		if (this.eventListeners.Contains (action))
		{
			this.eventListeners.Remove (action);
		}
	}

	public void RemoveListener (System.Action action)
	{
		if (this.eventListenersNoParams.Contains (action))
		{
			this.eventListenersNoParams.Remove (action);
		}
	}

	public void RemoveAllListeners ()
	{
		this.eventListeners.Clear ();
		this.eventListenersNoParams.Clear ();
	}

	public void NotifyListeners (Parameters parameters)
	{
		for (int i = 0; i < this.eventListeners.Count; i++)
		{
			System.Action<Parameters> action = this.eventListeners[i];

			action (parameters);
		}
	}

	public void NotifyListeners ()
	{
		for (int i = 0; i < this.eventListenersNoParams.Count; i++)
		{
			System.Action action = this.eventListenersNoParams[i];

			action ();
		}
	}
}
