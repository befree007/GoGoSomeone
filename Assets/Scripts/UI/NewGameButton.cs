using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Preview", LoadSceneMode.Single);
    }
}
