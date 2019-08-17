using UnityEngine;
using System.Collections;

public class CollideManually : MonoBehaviour
{
	public void Press()
	{
		DiceCollisionScript.colFlag = true;
	}
		
	public void Release()
	{
		DiceCollisionScript.colFlag = false;
	}

	void OnEnable()
	{
		DiceCollisionScript.colFlag = false;
	}
	void OnDisable()
	{
		DiceCollisionScript.colFlag = true;
	}
}