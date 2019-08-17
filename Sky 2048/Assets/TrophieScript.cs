using UnityEngine;
using System.Collections;

public class TrophieScript : MonoBehaviour {
	float curpos;
	bool istrophies = false;
	public GameObject trophies;
	public static float newdeltatime;

	public GameObject height;
	IEnumerator Activate(bool trophiebool)
	{
		if (!trophiebool) 
		{
			trophies.SetActive(false);

		}
		else if (trophiebool) 
		{
//			yield return new WaitForSeconds(1.0f);
			trophies.SetActive(true);
		}
		yield return null;
	}


	void OnClick()
	{
		istrophies = !istrophies;

		if (istrophies) 
		{
			Camera.main.transform.rotation = Quaternion.Euler(0,90,0);
			curpos = height.GetComponent<UISlider>().value;

			height.GetComponent<UISlider>().value = 0.288f;
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 17f, Camera.main.transform.position.z);

			print ("shit");
			
		}
		else if(!istrophies)
		{
			height.GetComponent<UISlider>().value = curpos;
			Camera.main.transform.rotation = Quaternion.Euler(0,0,0);
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, -2.5f, Camera.main.transform.position.z);
			
		}

		StartCoroutine ("Activate", istrophies);

//
//		StartScript.starten = !StartScript.starten;
//		
//	if(Time.timeScale > 0)
//	{
//		Camera.main.audio.Pause();
//		Time.timeScale = 0;
//	}
//	else
//	{	
//		Time.timeScale = PauseScript.spielGeschwindigkeit;
//		
//		Camera.main.audio.Play();
//	}
	}
}
