using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// enables the usage of your scenes.
using UnityEngine.SceneManagement;
// Allows interaction with buttons.
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameActive;

    private int _score;
    private float _spawnRate = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    /// <summary>
    /// Updates the score by adding a value.
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void UpdateScore(int scoreToAdd)
    {
        // Add the score.
        _score += scoreToAdd;

        // Set the content of the text.
        scoreText.text = "Score: " + _score;
    }

    /// <summary>
    /// Ends the game.
    /// </summary>
    public void GameOver()
    {
        // Sets the game over text component to enabled.
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    /// <summary>
    /// Restarts the game when the restart button is clicked.
    /// </summary>
    public void RestartGame()
    {
        // Takes the active scene and loads it.
        SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StarGame()
    {
        _score = 0;
        isGameActive = true;

        StartCoroutine(SpawnTarget());
    }
}