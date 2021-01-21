using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Enables the interaction with the UI, for this specific the buttons.
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;

    public int difficulty;
    
    private GameManager _gameManager;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        
        button = GetComponent<Button>();
        // Adds a listener when the button is clicked, perform method.
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SetDifficulty()
    {
        Debug.Log($"{button.gameObject.name} has been clicked.");
        _gameManager.StarGame(difficulty);
    }
}
