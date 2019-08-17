using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour
{
		public static int wuerfelAnzahl;

		public GameObject objOrig;
		public static Material mat;
		float spawnxpunkt = 7;
		public float spawnypunkt = 7;
		public float warteZeit = 2.0f;
		Vector3 cameraPosition;
		public static float kameray = 49f;
		public int numberOfDices = 630;
		public static List<GameObject> poolDices;
		GameObject obj;
		public int wuerfelErlaubt = 500;

		public GameObject spawnzeit;
		public GameObject camhoehe;
		public GameObject spawnhoehe;

	public Material day1;
	public Material night1;
	public Material day2;
	public Material night2;


	UILabel scoretxtlbl;
	UILabel dicetxtlbl;
	public GameObject scoretext;
	public GameObject dicetext;
	public Transform transpapa;
	

	void Start()
	{
		AudioListener.volume = 0f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		scoretxtlbl = scoretext.GetComponent<UILabel> ();
		dicetxtlbl = dicetext.GetComponent<UILabel> ();
		
		StartCoroutine("Spawningg");
	}


	void Awake()
	{
		mat = (Material)Resources.Load("1");


		poolDices = new List<GameObject> ();
		for (int i = 0; i < numberOfDices; i++) 
			{
		obj = (GameObject)Instantiate (objOrig);
		obj.transform.parent = transpapa;
		
		obj.SetActive (false);
		poolDices.Add (obj);
			}
				
	}


	public static GameObject GetCleanCube()
	{


	GameObject cCube = Spawn.poolDices[0];
	Spawn.poolDices.Remove(cCube);
	cCube.renderer.material = Spawn.mat;
	cCube.name = Spawn.mat.name;
	cCube.gameObject.GetComponent<DiceCollisionScript>().zahlwert = 2;
	return cCube;

	}

	public static void PutCubeBack(GameObject bCube)
	{

	if (bCube.gameObject)
	{	

	bCube.SetActive(false);
	Spawn.poolDices.Insert(0,bCube);
		}
	}


	IEnumerator Spawningg ()
	{
		if (Spawn.wuerfelAnzahl < wuerfelErlaubt && StartScript.starten) {
			Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-(Mathf.Abs (spawnxpunkt)), Mathf.Abs (spawnxpunkt)), spawnypunkt, 0f);

				GameObject objc = GetCleanCube();
				
				objc.transform.position = spawnPosition;
				objc.transform.rotation = Quaternion.Euler (0.0f, 0.0f, UnityEngine.Random.Range (0.0f, 360.0f));
				objc.SetActive (true);

		}

	yield return new WaitForSeconds(warteZeit);
	StartCoroutine("Spawningg");

	}



	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
						Application.Quit (); 
		}

		string zeit = System.DateTime.Now.ToString ("HH");
		if ( System.Int32.Parse(zeit) >= 12f && (float) System.Int32.Parse(zeit) <= 23f ) 
		{
			if ( System.Int32.Parse(zeit) >= 18f && (float) System.Int32.Parse(zeit) <= 23f ) 
			{
				RenderSettings.skybox = day1;
			}
			else 
			{
				RenderSettings.skybox = day2;
			}
		}
		else
		{
			
			if ( System.Int32.Parse(zeit) >= 0f && (float) System.Int32.Parse(zeit) <= 11f ) 
			{
				RenderSettings.skybox = night1;
			}
			else 
			{
				RenderSettings.skybox = night2;
			}
		}



		UISlider sz = spawnzeit.GetComponent<UISlider>();
		UISlider ch = camhoehe.GetComponent<UISlider>();
		UISlider sh = spawnhoehe.GetComponent<UISlider>();

		scoretxtlbl.text = "Score: " + DiceCollisionScript.Score;
		dicetxtlbl.text = "Dice: " + Spawn.wuerfelAnzahl;

		warteZeit = Mathf.Lerp(1f, 0.02f, sz.value);
		Spawn.kameray = Mathf.Lerp(-2.5f, 53f, ch.value);
		spawnypunkt = Mathf.Lerp(-5.5f, 30f, sh.value);

		cameraPosition = new Vector3 (this.transform.position.x, Spawn.kameray, this.transform.position.z);

		this.transform.position = Vector3.Lerp (this.transform.position, cameraPosition, Time.deltaTime* 10f);


	}

}
