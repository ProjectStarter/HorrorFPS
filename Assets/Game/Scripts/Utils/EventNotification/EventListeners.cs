using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

//note by carl.z
//this script makes use of System.Diagnostics
//so, to debug, complete the namespace UnityEngine.Debug

public class EventListeners {
	private static EventListeners instance;

	public Dictionary<string, ListenersList> eventListeners;

	public static EventListeners Instance
	{
		get
		{
			if (instance == null)
				instance = new EventListeners ();

			return instance;
		}
	}

	private EventListeners ()
	{
		this.eventListeners = new Dictionary<string, ListenersList> ();
	}

	public void AddListener (string eventName, System.Action<Parameters> action)
	{
		if (this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventListener = this.eventListeners[eventName];
			eventListener.AddListener (action);
		}

		else
		{
			ListenersList eventListener = new ListenersList ();
			eventListener.AddListener (action);
			this.eventListeners.Add (eventName, eventListener);
		}
	}

	public void AddListener (string eventName, System.Action action)
	{
		if(this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventListener = this.eventListeners[eventName];
			eventListener.AddListener (action);
		}

		else
		{
			ListenersList eventListener = new ListenersList ();
			eventListener.AddListener (action);
			this.eventListeners.Add (eventName, eventListener);
		}
	}

	public void RemoveListener (string eventName)
	{
		if(this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventListener = this.eventListeners[eventName];
			eventListener.RemoveAllListeners ();
			this.eventListeners.Remove (eventName);
		}
	}

	public void RemoveActionAtListener (string eventName, System.Action action)
	{
		if (this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventListener = this.eventListeners[eventName];
			eventListener.RemoveListener (action);
		}
	}

	public void RemoveActionAtListener(string eventName, System.Action<Parameters> action)
	{
		if (this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventObserver = this.eventListeners[eventName];
			eventObserver.RemoveListener (action);
		}
	}

	public void RemoveAllListeners ()
	{
		foreach(ListenersList eventListener in this.eventListeners.Values)
		{
			eventListener.RemoveAllListeners ();
		}

		this.eventListeners.Clear ();
	}

	//note by carl.z
	//it is not advisable to use this function when at least one listener
	//has a handler that is a method from another class
	//(which honestly is already a bad practice in itself)
	public void RemoveAllListenersHere ()
	{
		//get script where caller of this method is declared
		StackTrace stackTrace = new StackTrace();
		System.Type type = stackTrace.GetFrame (1).GetMethod ().DeclaringType;

		List<string> removeKeys = new List<string> ();

		foreach(ListenersList eventListener in this.eventListeners.Values)
		{
			//check if every handler has the same declaringtype as the calling method
			//if so, remove
			if (eventListener.EventListeners != null)
			{
				for (int i = 0; i < eventListener.EventListeners.Count; i++)
				{
					if (eventListener.EventListeners[i].Method.DeclaringType == type)
					{
						eventListener.RemoveAllListeners ();
					}
				}
			}
			for (int i = 0; i < eventListener.EventListenersNoParams.Count; i++)
			{
				if (eventListener.EventListenersNoParams[i].Method.DeclaringType == type)
				{
					eventListener.RemoveAllListeners ();
				}
			}
		}

		//check for listeners that have been removed then pend them to be cleared from the collection
		foreach (KeyValuePair<string, ListenersList> pair in EventListeners.Instance.eventListeners)
		{
			if (pair.Value.EventListeners.Count <= 0 && pair.Value.EventListenersNoParams.Count <= 0)
			{
				removeKeys.Add (pair.Key);
			}
		}

		//remove empty listeners
		foreach (string key in removeKeys)
		{
			eventListeners.Remove (key);
		}
	}

	public void DispatchEvent (string eventName)
	{
		if (this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventListener = this.eventListeners[eventName];
			eventListener.NotifyListeners ();
		}
	}

	public void DispatchEvent (string eventName, Parameters parameters)
	{
		if (this.eventListeners.ContainsKey (eventName))
		{
			ListenersList eventListener = this.eventListeners[eventName];
			eventListener.NotifyListeners (parameters);
		}
	}
}
