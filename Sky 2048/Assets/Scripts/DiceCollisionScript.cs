using UnityEngine;
using System.Collections;
using System;

public class DiceCollisionScript : MonoBehaviour
{

		public static int[] zahlwertArray = {
				2,
				4,
				8,
				16,
				32,
				64,
				128,
				256,
				512,
				1024,
				2048,
				4096,
				8192,
				16384,
				32768,
				65536,
				131072
		};
		public Material[] materials;
		public static int Score;
		public int zahlwert ;
		public static bool colFlag = true;


		void OnEnable()
		{
//		this.transform.localScale = Vector3.one;
			
			Spawn.wuerfelAnzahl++;
		}
		void OnDisable()
		{
			Spawn.wuerfelAnzahl--;

		}

		public static void IncreaseScore (GameObject ding)
		{
				DiceCollisionScript dcs = ding.GetComponent<DiceCollisionScript> ();
				Score += dcs.zahlwert; 
		}
		
//	void FixedUpdate()
//	{
//		this.transform.localScale = Vector3.Lerp (this.transform.localScale, Vector3.one, Time.deltaTime * 2f);
//	}

		public static void SimpleExplosion(GameObject ding)
		{
		DiceCollisionScript dcs = ding.GetComponent<DiceCollisionScript> ();
		GameObject explosionAnimation = (GameObject)Resources.Load<GameObject> ("Boom");
		GameObject vfx = (GameObject) Instantiate(explosionAnimation, dcs.transform.position, dcs.transform.rotation);
		DestroyObject(vfx, 1.5f);
		}

		void OnMouseDown ()
		{

			if (this.gameObject != null) 
			{
			Spawn.PutCubeBack(this.gameObject);
			IncreaseScore(this.gameObject);

			SimpleExplosion(this.gameObject);
			}
		}

	void OnCollisionStay (Collision other)
	{
		if (colFlag) 
		{
			if (other.gameObject.name == this.name)
			{
				if (other.rigidbody.velocity.y > this.rigidbody.velocity.y) 
				{
					if (this.name != 17.ToString ()) 
					{
						if (this.gameObject) 
						{											
							Spawn.PutCubeBack (other.gameObject);
							int j = (System.Int32.Parse (this.name));
							this.zahlwert = zahlwertArray [j];						
							this.renderer.sharedMaterial = materials [j];
							j++;
							this.name = j.ToString ();	
						}
					}
				}						
			}
		}
	}	
}