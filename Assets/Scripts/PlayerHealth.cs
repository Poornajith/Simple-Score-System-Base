using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Image healthBarFillImage;
    [SerializeField] private GameObject gameOverPanel;

    private float currentHealth;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0f)
        {
            EndGame();
        }
        healthBarFillImage.fillAmount = currentHealth / maxHealth;
    }

    private void EndGame()
    {
        gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        ScoreManager.instance.GameOver();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
