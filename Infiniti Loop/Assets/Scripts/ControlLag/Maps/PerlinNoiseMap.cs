using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseMap : MonoBehaviour
{

	int preservedPlaces = 3;


	public GameObject object01;
	public GameObject object02;
	public GameObject object03;
	public GameObject object04;
	public GameObject object05;
	public GameObject object06;
	public GameObject object07;
	public GameObject object08;// Grass
	public GameObject object09;//Big stone
	public GameObject object10;//Woodstack
	public GameObject object11;//Beaver
	public GameObject object12;// Stor WallStone
	public GameObject object13;//Mushroom
	public GameObject object14;//energy Plant

	//Milestones
	public GameObject mileStone01;
	public GameObject mileStone02;
	public GameObject mileStone03;
	public GameObject mileStone04;
	public GameObject mileStone05;

	//entrance object
	public GameObject entranceObj;

	//exit object
	public GameObject exitObj;

	//List<Vector3> spawnPoints;

	private int seed;
// 9; 8788;
	public float scale;
	public float width;
	public float height;
	public float detailScale;

	int counter = 0;

	List<SpawnObject> spawnObjects = new List<SpawnObject> ();

	void InitSpawnObjects ()
	{
		spawnObjects.Add (new SpawnObject (object08, 0.0f, 1.0f)); //Spawn Grass 1
		spawnObjects.Add (new SpawnObject (object01, 0.8f, 1.0f)); //8Meter
		spawnObjects.Add (new SpawnObject (object02, 0.6f, 0.8f)); //6 meter?
		spawnObjects.Add (new SpawnObject (object03, 0.54f, 0.6f)); //2 meter
		spawnObjects.Add (new SpawnObject (object04, 0.52f, 0.54f)); // Stuppe
		spawnObjects.Add (new SpawnObject (object13, 0.505f, 0.52f)); // Mushroom
		spawnObjects.Add (new SpawnObject (object05, 0.47f, 0.505f)); // blomst
		spawnObjects.Add (new SpawnObject (object14, 0.34f, 0.35f)); //Energy Plant
		spawnObjects.Add (new SpawnObject (object11, 0.32f, 0.34f)); //Beaver
		spawnObjects.Add (new SpawnObject (object10, 0.315f, 0.32f)); //Woodstack
		//spawnObjects.Add (new SpawnObject (object08, 0.18f, 0.315f)); //Spawn Grass 1
		spawnObjects.Add (new SpawnObject (object06, 0.14f, 0.18f)); // Lille sten
		spawnObjects.Add (new SpawnObject (object07, 0.05f, 0.14f)); // stor sten
		spawnObjects.Add (new SpawnObject (object09, 0.025f, 0.05f)); // Lille WallStone
		spawnObjects.Add (new SpawnObject (object12, 0.0f, 0.025f)); // Stor WallStone

	

	}
	// Use this for initialization
	void Awake ()
	{
		seed = Random.Range (0, 10000);
		//spawnPoints = new List<Vector3>();
	}

	void Start ()
	{
		InitSpawnObjects ();
		SpawnMilestone (mileStone03);
		SpawnLevel ();
		spawnEntrance (entranceObj);
		spawnExit (exitObj);


	}

	void spawnEntrance(GameObject entranceObj){
		float x = width / 2;
		float z = 0;
		Instantiate (entranceObj, new Vector3 (x*2, 0, z*2), Quaternion.identity); 

	}

	void spawnExit(GameObject exitObj){
		float x = width / 2;
		float z = height;
		Instantiate (exitObj, new Vector3 (x*2, 0, z*2), Quaternion.identity);
	}

	void SpawnMilestone(GameObject objToSpawn)
	{
		//Spawn object
		for (int i = 0; i < preservedPlaces; i++) {
			float x = Random.Range (10, width-10);
			float z = Random.Range (10, height-10);
			Instantiate (objToSpawn, new Vector3 (x*2, 0, z*2), Quaternion.Euler (0, Random.Range (0, 360), 0));

			//Check if position is near last spawn

		}
	}
//	void SpawnMilestone()
//	{
//		for (int i = 0; i < preservedPlaces; i++) {
//			float x = Random.Range (0, width);
//			float y = Random.Range (0, height);
//			x = Mathf.Clamp (x, 10, width - 10);
//			y = Mathf.Clamp (y, 10, height - 10);
//			spawnPoints.Add (new Vector3(x, y));
//			Instantiate (mileStone01, spawnPoints, Quaternion.identity);
//		}
//	}

	void SpawnLevel()
	{
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				//Debug.Log ("Counter: " + counter + "Seed: " + seed + "Noise: " + Mathf.PerlinNoise ((x/width)*scale, (z/height)*scale));

				//float pNWidth = ((x / width) * scale) / detailScale;
				//float pNHeight = ((z / height) * scale) / (detailScale/2);
				float pNWidth = x / scale;
				float pNHeight = z / scale;

				foreach (var item in spawnObjects) {
					GameObject go = InstantiateObject (item.obj, item.smallerThan, item.biggerThan, pNWidth, pNHeight, x, z);
					//if (go != null & Random.Range(0,2) > 0)
					//	go.GetComponent<MeshRenderer> ().enabled = false;
				}
			}
		}
	}

	GameObject InstantiateObject (GameObject obj, float smallerThan, float biggerThan, float pNWidth, float pNHeight, int x, int z)
	{
		var perlinNoiseCache = Mathf.PerlinNoise (seed + pNWidth, seed + pNHeight);
		perlinNoiseCache = Mathf.Clamp (perlinNoiseCache, 0.0f, 1.0f); //Perlin noise kan ikke komme over 1.0 eller under 0.0
		if (perlinNoiseCache >= smallerThan && perlinNoiseCache <= biggerThan) {
			//counter++;
			//float randomRotation = Random.Range(0,360);

			GameObject go = Instantiate (obj, new Vector3 (x * detailScale, 0, z * detailScale), Quaternion.Euler (0, Random.Range (0, 360), 0));
			return go;
		}
		return null;
	}

	// Update is called once per frame
	void Update ()
	{
			
	}
}



public class SpawnObject
{
	public SpawnObject (GameObject obj, float smallerThan, float biggerThan)
	{
		this.obj = obj;
		this.smallerThan = smallerThan;
		this.biggerThan = biggerThan;
	}

	public GameObject obj;
	public float smallerThan;
	public float biggerThan;
}



