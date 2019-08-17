using UnityEngine;
using System.Collections;

public class SoundChk : MonoBehaviour {

	void Awake () {
		if (PlayerPrefs.GetInt("Sound",1) == 1) 
		{
			activieren(false);
			this.GetComponent<UIToggle>().startsActive = false;
		}
		else if (PlayerPrefs.GetInt("Sound",1) == 0)
		{
			activieren(true);
			this.GetComponent<UIToggle>().startsActive = true;
		}
	}
	
	void OnClick()
	{
		if (this.GetComponent<UIToggle>().value == true) 
		{
			PlayerPrefs.SetInt("Sound",0);	
			activieren(true);
		}
		else if (this.GetComponent<UIToggle>().value == false)
		{
			PlayerPrefs.SetInt("Sound",1);
			
			activieren(false);
		}
	}

	void activieren(bool ac)
	{
		if (ac) {
		AudioListener.volume = 100;
			
				}
		else if (!ac) {
			AudioListener.volume = 0;
			
		}
	}
}
