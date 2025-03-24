using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text emptyNameTxt;
    [SerializeField] private TMP_InputField playerNameIn;

    public string playerName;
    public string bestPlayerName;
    public string allSavedData;

    public int score;
    public int highScore;

    public bool isGameOver = false;

    private string saveFilepath;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        saveFilepath = Application.persistentDataPath + "/savefile.json";
    }
    private void Start()
    {
        LoadHighScore();
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = bestPlayerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilepath, json);
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int highScore;
    }

    public void LoadHighScore()
    {
        if (File.Exists(saveFilepath))
        {
            ReadAllData();
            SaveData data = JsonUtility.FromJson<SaveData>(allSavedData);
            bestPlayerName = data.bestPlayerName;
            highScore = data.highScore;
            highScoreTxt.text = "Best Score: " + bestPlayerName + " : " + highScore;
        }
        else
        {
            bestPlayerName = "No Name";
            highScore = 0;
            highScoreTxt.text = "Best Score: " + bestPlayerName + " : " + highScore;
        }
    }

    public void UpdateHighScore()
    {
        highScore = score;
        bestPlayerName = playerName;
        highScoreTxt.text = "Best Score: " + bestPlayerName + " : " + highScore;
        SaveHighScore();
    }

    public void ReadAllData()
    {
        allSavedData = File.ReadAllText(saveFilepath);
        Debug.Log(allSavedData);
    }

    public void UpdatePlayerName()
    {
        playerName = playerNameIn.text;
    }

    public void StartNew() 
    {
        if (playerNameIn.text == "")
        {
            emptyNameTxt.gameObject.SetActive(true);
            return;
        }
        UpdatePlayerName();
        score = 0;
        isGameOver = false;
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        isGameOver = true;
        if (score > highScore)
        {
            UpdateHighScore();
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

   
}
