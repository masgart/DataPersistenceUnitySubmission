using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIInteraction : MonoBehaviour
{

    public GameObject NameInput;
    public GameObject Highscore;

    private void Start()
    {
        NameInput.GetComponent<TMP_InputField>().text = SharedInformation.Instance.GetPlayerName();
        Highscore.GetComponent<TMP_Text>().text = "Highscore: " + SharedInformation.Instance.HighscorePlayer + ": " + SharedInformation.Instance.Highscore;
    }

    public void StartGame()
    {
        SharedInformation.Instance.SetPlayerName(NameInput.GetComponent<TMP_InputField>().text);
        SharedInformation.Instance.SavePersistent();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SharedInformation.Instance.SavePersistent();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
