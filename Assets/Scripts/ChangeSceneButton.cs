using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void LeaderBoard()
    {
        SceneManager.LoadScene(2);
    }

}
