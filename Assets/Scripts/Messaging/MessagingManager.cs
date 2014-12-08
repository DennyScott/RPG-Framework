using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MessagingManager : MonoBehaviour {

	//Static singleton property
	public static MessagingManager Instance { get; private set; }

	public ScriptingObjects MyWaypoints;

	//public property for manager
	private List<Action> subscribers = new List<Action>();

	void Awake() {
		Debug.Log ("Messaging Manager Started");

		//First we check if there are any other instances conflicting
		if (Instance != null && Instance != this){
			//Destroy other instances if it's not the same
			Destroy(gameObject);
		}

		//Save our current singleton instance
		Instance = this;

		//Make sure that the instance is not destroyed between scenes
		DontDestroyOnLoad(gameObject);

		object o = Resources.Load("SavedGames/newPositionManager");
		MyWaypoints = (ScriptingObjects)o;

		Debug.Log (MyWaypoints);
	}

	//The Subscribe method for manager
	public void Subscribe(Action subscriber){
		Debug.Log("Subscriber registered");
		subscribers.Add (subscriber);
	}

	public void UnSubscribe(Action subscriber){
		Debug.Log ("Subscriber Removed");
		subscribers.Remove (subscriber);
	}

	public void ClearAllSubscribers() {
		subscribers.Clear ();
	}

	public void Broadcast(){
		Debug.Log ("Broadcast requested, No of Subscribers = " + subscribers.Count);

		foreach(Action subscriber in subscribers){
			subscriber();
		}
	}


}
