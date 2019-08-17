using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {


	public static bool starten = false ;
	void Awake()
	{
		Time.timeScale = 0f;
		DiceCollisionScript.Score = 0;
		Spawn.wuerfelAnzahl = 0;
	}
	void OnClick()
	{

				Application.LoadLevel(Application.loadedLevel);
				starten = false;

	}
}

