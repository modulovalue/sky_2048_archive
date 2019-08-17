using UnityEngine;
using System.Collections;

public class TutorialChkButton : MonoBehaviour {

	public GameObject[] lbls;
	// Use this for initialization
	void Awake () {
	if (PlayerPrefs.GetInt("Tutorial",1) == 1) 
		{
			activieren(false);
			this.GetComponent<UIToggle>().startsActive = false;
		}
	else if (PlayerPrefs.GetInt("Tutorial",1) == 0)
		{
			activieren(true);
			this.GetComponent<UIToggle>().startsActive = true;
		}
	}
	
	void OnClick()
	{
		if (this.GetComponent<UIToggle>().value == true) 
		{
			PlayerPrefs.SetInt("Tutorial",0);	
			activieren(true);
		}
		else if (this.GetComponent<UIToggle>().value == false)
		{
			PlayerPrefs.SetInt("Tutorial",1);

			activieren(false);
		}
	}

	void activieren(bool ac)
	{
		foreach (var lbl in lbls) 
		{
			lbl.SetActive(ac);	
		}
	}
}
