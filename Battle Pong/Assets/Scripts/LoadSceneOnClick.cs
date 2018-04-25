using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadOnClick(int sceneIndex) {

		GameInfo.playerCount = sceneIndex;
		if(sceneIndex == 0)
		{
			SceneManager.LoadScene (sceneIndex);
		} else SceneManager.LoadScene("Controller Select");
		//now that all scenes go to Controller Select first, I just changed it here -Aj
	}
}
