using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    //MAIN MENU SECTION
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "Kaif's Scene" );
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


}
