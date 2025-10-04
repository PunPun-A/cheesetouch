using UnityEngine;
using TMPro;
using System.Collections; // Important for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to your UI TextMeshPro object
    public int currentScore = 0; // The actual score value
    public GameObject CheesText;
    public GameObject TouchSound;
    public GameObject WinScene;
    public GameObject Player;

    void Start()
    {
        currentScore = 0;
        UpdateScoreDisplay();
    }

    private void Update()
    {

        if(currentScore >= 100)
        {
            FindAnyObjectByType<CheeseSpawner>().timeBetweenSpawns = 1.5f;
        }
        if (currentScore >= 300)
        {
            FindAnyObjectByType<CheeseSpawner>().timeBetweenSpawns = 1f;
        }
        if (currentScore >= 500)
        {
            FindAnyObjectByType<CheeseSpawner>().timeBetweenSpawns = 0.5f;
        }
        if (currentScore >= 1000)
        {
            WinScene.SetActive(true);
            FindAnyObjectByType<PlayerMovement>().enabled = false;
            Player.SetActive(false);

        }

    }
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
        StartCoroutine(HideCheeseTextAfterDelay());
        StartCoroutine(PlayTouchSound());

    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
    
    public IEnumerator HideCheeseTextAfterDelay()
    {
        CheesText.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        CheesText.SetActive(false);
        
    }

    public IEnumerator PlayTouchSound()
    {
        TouchSound.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        TouchSound.SetActive(false);
    }
}
