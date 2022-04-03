using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(sceneName: "Runner");
    }

}
