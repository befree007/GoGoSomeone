using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [SerializeField] private Bookmaker _bookmaker;

    public void SaveDataGame()
    {
        PlayerPrefs.SetFloat("Balance", (float)_bookmaker.Balance);
        PlayerPrefs.SetFloat("Debt", (float)_bookmaker.Debt);
        PlayerPrefs.SetInt("Day", _bookmaker.DayCount);
        PlayerPrefs.Save();

        Debug.Log("Game data saved!");
    }

    public void ResetSaves()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Data reset complete");
    }
}
