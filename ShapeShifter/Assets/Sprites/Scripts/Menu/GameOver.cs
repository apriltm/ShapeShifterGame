using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName: "Kaif's Scene");
    }
    
    
}
