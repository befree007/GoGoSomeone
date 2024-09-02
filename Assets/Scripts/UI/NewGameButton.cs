using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private SaveGame _saveGame;

    private const string _loadScene = "Preview";

    public void NewGame()
    {
        Time.timeScale = 1f;
        _saveGame.ResetSaves();
        SceneManager.LoadScene(_loadScene, LoadSceneMode.Single);
    }
}
