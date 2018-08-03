using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour {
public Button[] MyButtons;
	public Sprite LockImage;

	void Start()
	{
		int Level= PlayerPrefs.GetInt("Level" , 1);

		for(int i = Level ; i  < MyButtons.Length ; i++)
		{
			MyButtons[i].GetComponent<Image>().sprite = LockImage;
			MyButtons[i].GetComponent<Button>().interactable = false;

		}
	}

	public void levelclicked(int a)
	{
		PlayerPrefs.SetInt("CurrentLevel", a);
		SceneManager.LoadScene(a.ToString());
	}
}
