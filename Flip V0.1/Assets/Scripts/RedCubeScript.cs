using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeScript : MonoBehaviour {

	public GameObject RedCube;
	public Color mycolor;
	public GameObject CubeSolidRed1;
	public GameObject CubeSolidRed2;
	void OnTriggerEnter(Collider col)
	{
		 if (col.gameObject.tag == "Player")
		 {
			 RedCube.GetComponent<Renderer> ().material.color = mycolor;
			 Destroy(CubeSolidRed1);
			 Destroy(CubeSolidRed2);
		 }
	}
}
