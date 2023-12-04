using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public GameObject player;
    public float healthAmount;

    private PlayerHealth playerHealth;
    public string playerTag;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerTag = player.tag;
    }

    void Update()
    {
        healthAmount = playerHealth.GetCurrentHealth();
        healthBar.fillAmount = healthAmount / 100;

    }

}
