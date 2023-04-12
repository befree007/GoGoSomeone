using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    private const string _loadScene = "Preview";

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_loadScene, LoadSceneMode.Single);
    }
}
