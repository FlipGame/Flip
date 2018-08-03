using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeScript : MonoBehaviour {

	public GameObject BlueCube;
	public Color mycolor;
	public GameObject CubeSolidBlue1;
	public GameObject CubeSolidBlue2;
	void OnTriggerEnter(Collider col)
	{
		 if (col.gameObject.tag == "Player")
		 {
			 BlueCube.GetComponent<Renderer> ().material.color = mycolor;
			 Destroy(CubeSolidBlue1);
			 Destroy(CubeSolidBlue2);
		 }
	}
}
