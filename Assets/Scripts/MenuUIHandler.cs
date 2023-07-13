using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text inputText;
    // Start is called before the first frame update
    public void NewNameInput()
    {
        ScenesManager.Istance.playerName = inputText.text;
    }


    public void Exit()
    {
        //savename
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
