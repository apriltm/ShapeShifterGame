using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour {

    
    public Animator loaderanim;
    

    private string loadProgress = "Loading...";
	public void LoadLevel (int sceneNum)
    {
        loaderanim.SetTrigger("end");
        StartCoroutine(LoadAsynchronously(sceneNum));
        
    }
    
    private string lastloadProgress = null;
    IEnumerator LoadAsynchronously (int sceneNum)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNum);
        loaderanim.SetTrigger("end");




        while (!operation.isDone)
        {
            if (operation.progress < 0.9f)
            {
                loadProgress = "Loading: " + (operation.progress * 100f).ToString("F0") + "%";
                //slider.value = operation.progress;
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


    public void ReloadLevel()
    {

        SceneManager.LoadScene(sceneName: "NEWNATHAN");
        loaderanim.SetTrigger("end");
    }
   
}
