using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScene;

    public void MenuOpen()
    {
        Time.timeScale = 0f;
        _pauseScene.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        _pauseScene.SetActive(false);
    }    
}
