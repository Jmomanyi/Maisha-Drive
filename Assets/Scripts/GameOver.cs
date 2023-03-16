using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public Carmovement car;
   
    public Button restartButton; 


    void Start()
    {
        // Add listener to restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
       Debug.Log(car.currentHealth);
        // Check player's health
        if (car.currentHealth <= 0)
        {
            // Show game over canvas
            gameObject.SetActive(true);
        }
        else
        {
            // Hide game over canvas
            gameObject.SetActive(false);
        }
    }

    void RestartGame()
    {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
}
