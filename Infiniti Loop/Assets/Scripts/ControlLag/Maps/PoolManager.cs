﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	// En Dictionary der holder på vores prefabs
	Dictionary<int,Queue<GameObject>> poolDictionary = new Dictionary<int,Queue<GameObject>> ();

	static PoolManager _instance;

	public static PoolManager instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<PoolManager> ();
			}
			return _instance;
		}
	}

	public void CreatePool(GameObject prefab, int poolSize)
	{
		int poolKey = prefab.GetInstanceID ();

		//Make sure the poolkey is not already in the dictionary
		if (!poolDictionary.ContainsKey (poolKey)) {
			poolDictionary.Add (poolKey, new Queue<GameObject> ());

			for (int i = 0; i < poolSize; i++) {
				GameObject newObject = Instantiate (prefab) as GameObject;
				newObject.SetActive (false);
				poolDictionary [poolKey].Enqueue (newObject);
			}
		}
	}

	public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		int poolKey = prefab.GetInstanceID ();

		if (poolDictionary.ContainsKey (poolKey)) {
			GameObject objectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (objectToReuse);

			objectToReuse.SetActive (true);
			objectToReuse.transform.position = position;
			objectToReuse.transform.rotation = rotation;
		}
	}
}
