using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text emptyNameTxt;
    [SerializeField] private TMP_InputField playerNameIn;

    private void Start()
    {
        highScoreTxt.text = "Best Score: " + MainManager.instance.bestPlayerName + " - " + MainManager.instance.highScore;
    }
    public void StartNew()
    {
        if (playerNameIn.text == "")
        {
            emptyNameTxt.gameObject.SetActive(true);
            return;
        }
        AudioManager.instance.PlayButtonClickSound();
        MainManager.instance.UpdatePlayerName();
        MainManager.instance.score = 0;
        MainManager.instance.isGameOver = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlayButtonClickSound();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
