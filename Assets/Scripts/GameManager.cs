using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;


    private int _score;

    private float _spawnRate = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
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

    public void GameOver()
    {
        // Sets the game over text component to enabled.
        gameOverText.gameObject.SetActive(true);
    }
}