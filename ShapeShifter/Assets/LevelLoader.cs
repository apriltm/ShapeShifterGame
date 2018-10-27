using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;

    private string loadProgress = "Loading...";
	public void LoadLevel (int sceneNum)
    {
        StartCoroutine(LoadAsynchronously(sceneNum));
    }
    
    private string lastloadProgress = null;
    IEnumerator LoadAsynchronously (int sceneNum)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNum);
       
        loadingScreen.SetActive(true);
        

        while (!operation.isDone)
        {
            if (operation.progress < 0.9f)
            {
                loadProgress = "Loading: " + (operation.progress * 100f).ToString("F0") + "%";
                slider.value = operation.progress;
            }
            else // if progress >= 0.9f the scene is loaded and is ready to activate.
            {
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }

                loadProgress = "Loading ready for activation, Press any key to continue";
            }

            if (lastloadProgress != loadProgress)
            {
                lastloadProgress = loadProgress;
                Debug.Log(loadProgress);
            }
            yield return null;
           
        }

        loadProgress = "Load Complete";
        Debug.Log(loadProgress);
    }
}
