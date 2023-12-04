using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Quit() {
        Application.Quit();
    }
    public void MapSelect() {
        SceneManager.LoadScene(1);
    }
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
    public void Map1() {
        SceneManager.LoadScene(2);
    }
    public void Credits() {
        SceneManager.LoadScene(3);
    }
    
}
