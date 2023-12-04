using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pellet") || (other.CompareTag("Pellet2")))
        {
            Destroy(other.gameObject);
        }
    }
}
