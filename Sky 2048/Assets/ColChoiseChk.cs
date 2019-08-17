using UnityEngine;
using System.Collections;

public class ColChoiseChk : MonoBehaviour {

	public GameObject col;
	public DiceCollisionScript dcs;
	void Awake () {
		if (PlayerPrefs.GetInt("Col",1) == 1) 
		{
			activieren(false);
			this.GetComponent<UIToggle>().startsActive = false;
		}
		else if (PlayerPrefs.GetInt("Col",1) == 0)
		{
			activieren(true);
			this.GetComponent<UIToggle>().startsActive = true;
		}
	}
	
	void OnClick()
	{
		if (this.GetComponent<UIToggle>().value == true) 
		{

			PlayerPrefs.SetInt("Col",0);

			activieren(true);
		}
		else if (this.GetComponent<UIToggle>().value == false)
		{
			PlayerPrefs.SetInt("Col",1);

			activieren(false);
		}
	}
	
	void activieren(bool ac)
	{
		col.SetActive (ac);
	}
}
