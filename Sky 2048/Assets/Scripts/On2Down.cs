using UnityEngine;
using System.Collections;

public class On2Down : MonoBehaviour
{
		GameObject[] obj;
		public string whichObjectToDestroy = "1";
		DiceCollisionScript diceCollisionScript;

		public void OnClick ()

		{
		obj = GameObject.FindGameObjectsWithTag ("Dice");

		foreach (GameObject objein in obj) 
		{	
		if (objein.name == whichObjectToDestroy) 
			{

			if (objein != null) 
				{

					DiceCollisionScript.IncreaseScore(objein);
					DiceCollisionScript.SimpleExplosion(objein);
					Spawn.PutCubeBack(objein);																			
				}
			}
		}
	}
}
