using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{ 
    public Animator transitionanim;

    public void LoadScene(string scenename)
    {
        
        StartCoroutine(CloseScene(scenename));

    }

    IEnumerator CloseScene(string scenename)
    {
        transitionanim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenename);
    }

}
