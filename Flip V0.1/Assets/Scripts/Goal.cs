using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public GameObject player;
	public Color mycolor;

	void OnTriggerEnter(Collider col)
	{
		 if (col.gameObject.tag == "Player")
		 {		
		player.GetComponent<Renderer> ().material.color = mycolor;
		Invoke("NextLevel" , 0.8f);
		int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
		int maxLevelReach = PlayerPrefs.GetInt("Level", 1);
		if (currentLevel ==maxLevelReach)
		PlayerPrefs.SetInt("Level" , maxLevelReach + 1);
		 }
	}

	public void NextLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex+1);
	}
}
