using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager Istance;

    public string playerName;
    public string highPlayerName;
    public int highScore;
    public Highscores highscores;

    private void Awake()
    {
        if (Istance != null)
        {
            Destroy(gameObject);
            return;
        }
        Istance = this;
        DontDestroyOnLoad(gameObject);


        //Load leaderboard

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        /*Highscores*/ highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (highscores == null)
        {
            highscores = new Highscores();
        }
        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        //Sort entry list by Score
        if (highscores.highscoreEntryList.Count <= 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        //Swap
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }

        }

        //Remove score worst then 10th
        if (highscores.highscoreEntryList.Count > 10)
        {
            for (int h = highscores.highscoreEntryList.Count; h > 10; h--)
            {
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }

        //Take best score
        highPlayerName = highscores.highscoreEntryList[0].name;
        highScore = highscores.highscoreEntryList[0].score;

    }


    public void AddHighscoreEntry(int score, string name)
    {

        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Load save Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            highscores = new Highscores();
        }
        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    // Single high score entry
    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;

    }


}
