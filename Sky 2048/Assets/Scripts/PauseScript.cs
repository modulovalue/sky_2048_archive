using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	
	Vector3 newCameraPosition;
	public static float spielGeschwindigkeit = 1.0f;

	public static void GlobalPause()
	{
		StartScript.starten = !StartScript.starten;
		
		if(Time.timeScale > 0)
		{
			Camera.main.audio.Pause();
			Time.timeScale = 0;
		}
		else
		{	
			Time.timeScale = spielGeschwindigkeit;
			Spawn.kameray = -2.5f;
			
			Camera.main.audio.Play();
		}

	}

	void OnClick()
	{	

		GlobalPause ();
	}
}
