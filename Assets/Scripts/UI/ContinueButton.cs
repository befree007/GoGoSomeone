using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Bookmaker _bookmaker;

    private const string _loadScene = "Game";

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        _bookmaker.LoadData();
        SceneManager.LoadScene(_loadScene, LoadSceneMode.Single);
    }       
}
