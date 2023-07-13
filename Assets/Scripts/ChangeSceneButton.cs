using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public Text noPlayerName;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartNew()
    {

        if (ScenesManager.Istance.playerName.Length > 0)
        {
            SceneManager.LoadScene(1);
            
        }
        else
        {
            StartCoroutine(NoPlayerName("Missing player name, go back to menu", 2));
        }

    }
    public void LeaderBoard()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator NoPlayerName(string message, float delay)
    {
        noPlayerName.text = message;
        noPlayerName.enabled = true;
        yield return new WaitForSeconds(delay);
        noPlayerName.enabled = false;
    }

}
