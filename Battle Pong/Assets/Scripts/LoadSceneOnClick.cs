using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadOnClick(int sceneIndex) {

		SceneManager.LoadScene ("NetworkingScene");
		PlayerPrefs.SetInt ("scene", sceneIndex);
	}

	public void ifPlayerChoosesPlay() {
		SceneManager.LoadScene (PlayerPrefs.GetInt("scene"));
	}
}
