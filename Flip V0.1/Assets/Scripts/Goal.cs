using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	public GameObject player;
	public Color mycolor;

	void OnTriggerEnter(Collider col)
	{
		 if (col.gameObject.tag == "Player")
		 {
			player.GetComponent<Renderer> ().material.color = mycolor;
		 }
	}
}
