using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    [Header("Game Over Screen")]
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private TextMeshProUGUI totalScoreTxt;
    [SerializeField] private TextMeshProUGUI playerNameTxt;

    [Header("Player Data")]
    public string playerName;
    public int score;
    public int highScore;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerName = MainManager.instance.playerName;
        highScore = MainManager.instance.highScore;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreTxt.text = "Score: " + score;
    }

    public void GameOver()
    {
        playerNameTxt.text = playerName;
        totalScoreTxt.text = score.ToString();

        MainManager.instance.score = score;
        MainManager.instance.GameOver();

        highScoreTxt.text = "High Score: " + MainManager.instance.bestPlayerName + " : " + MainManager.instance.highScore;
    }
}
