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
    
    private void Awake()
    {
        if (Istance != null)
        {
            Destroy(gameObject);
            return;
        }
        Istance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string highPlayerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highPlayerName = highPlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highPlayerName = data.highPlayerName;
            highScore = data.highScore;
        }
    }
}
