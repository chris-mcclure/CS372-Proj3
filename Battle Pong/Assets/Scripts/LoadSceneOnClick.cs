using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	GameObject music;
	void Start()
	{
		music = GameObject.FindGameObjectWithTag ("Music");
	}

	public void LoadOnClick(int sceneIndex) {
		GameInfo.playerCount = sceneIndex;
		if(sceneIndex == 0)
		{
			if (music.GetComponent<AudioSource> ().isPlaying) {
				Destroy (music);
			}
			SceneManager.LoadScene (sceneIndex);



			
		} else SceneManager.LoadScene("Controller Select");
		//now that all scenes go to Controller Select first, I just changed it here -Aj
	}
}
