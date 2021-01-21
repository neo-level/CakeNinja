using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Enables the interaction with the UI, for this specific the buttons.
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    private void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
