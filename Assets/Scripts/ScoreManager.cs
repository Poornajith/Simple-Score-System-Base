using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    public string playerName;
    public int score;
    public int highScore;
    public bool isGameOver = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isGameOver = false;
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
}
