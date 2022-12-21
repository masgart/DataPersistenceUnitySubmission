using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SharedInformation : MonoBehaviour
{
    public static SharedInformation Instance   { get; private set; }

    private string PlayerName;
    public string HighscorePlayer { get; set; }
    public int Highscore { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPersistent();
        }
    }

    public void SetPlayerName(string newName)
    {
        PlayerName = newName;
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

    public void LoadFromFile()
    {

    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highscorePlayer;
        public int highscore;
    }

    public void SavePersistent()
    {
        SaveData saveData = new SaveData();
        saveData.playerName = PlayerName;
        saveData.highscorePlayer = HighscorePlayer;
        saveData.highscore = Highscore;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPersistent()
    {
        string filename = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            PlayerName = saveData.playerName;
            HighscorePlayer = saveData.highscorePlayer;
            Highscore = saveData.highscore;
        }
    }
}
