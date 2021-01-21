﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    private int _score;

    private float _spawnRate = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // Set score to 0 on start of the game.
        UpdateScore(0);

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
            // Temp increment score on spawn to test if it works.
            UpdateScore(5);
        }
    }

    /// <summary>
    /// Updates the score by adding a value for every object that spawns => phase 1
    /// </summary>
    /// <param name="scoreToAdd"></param>
    private void UpdateScore(int scoreToAdd)
    {
        // Add the score.
        _score += scoreToAdd;

        // Set the content of the text.
        scoreText.text = "Score: " + _score;
    }
}