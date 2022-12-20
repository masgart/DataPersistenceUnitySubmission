using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedInformation : MonoBehaviour
{
    public static SharedInformation Instance   { get; private set; }

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
        }
    }

    private string PlayerName;

    public void SetPlayerName(string newName)
    {
        PlayerName = newName;
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }
}
