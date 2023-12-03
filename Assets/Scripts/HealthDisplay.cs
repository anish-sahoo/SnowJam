using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI player1HealthText;
    public TextMeshProUGUI player2HealthText;

    public PlayerHealth player1Health; // Reference to Player1's PlayerHealth script
    public PlayerHealth player2Health; // Reference to Player2's PlayerHealth script

    private int lastPlayer1Health;
    private int lastPlayer2Health;

    void Start()
    {
        // Assuming you have PlayerHealth scripts attached to the respective GameObjects
        player1Health = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerHealth>();
        player2Health = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerHealth>();

        // Set initial health values in the UI
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        // Update the TextMeshProUGUI elements only when health changes
        if (lastPlayer1Health != player1Health.GetCurrentHealth())
        {
            player1HealthText.text = "Player 1 Health: " + player1Health.GetCurrentHealth();
            lastPlayer1Health = player1Health.GetCurrentHealth();
        }

        if (lastPlayer2Health != player2Health.GetCurrentHealth())
        {
            player2HealthText.text = "Player 2 Health: " + player2Health.GetCurrentHealth();
            lastPlayer2Health = player2Health.GetCurrentHealth();
        }
    }

    void Update()
    {
        // Update the UI only when health changes
        UpdateHealthUI();
    }
}

