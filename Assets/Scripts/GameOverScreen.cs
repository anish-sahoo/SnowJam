using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    public GameObject player1;
    public GameObject player2;
    public void Setup()
    {
        gameObject.SetActive(true);
        // Get component of player health for player1
        PlayerHealth player1Health = player1.GetComponent<PlayerHealth>();
        // Get component of player health for player2
        PlayerHealth player2Health = player2.GetComponent<PlayerHealth>();
        if(player1Health.GetCurrentHealth() > player2Health.GetCurrentHealth())
        {
            playerText.text = "Player 1 wins!";
        }
        else
        {
            playerText.text = "Player 2 wins!";
        }
    }
}
