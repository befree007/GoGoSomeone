using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private const string _loadScene = "Menu";

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_loadScene, LoadSceneMode.Single);
    }
}
