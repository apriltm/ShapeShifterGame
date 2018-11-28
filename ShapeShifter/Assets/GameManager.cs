using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;

 
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("GAME OVER");
            gameHasEnded = true;
            SceneManager.LoadScene(sceneName: "Game Over");
            
        }
    }

    


}
