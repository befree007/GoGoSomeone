using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoseCompetitor : MonoBehaviour
{
    [SerializeField] private Bookmaker _bookmakerManager;

    public void ChoseCompetitorButton()
    {
        int index = Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text);
        _bookmakerManager.ChoseCompetitor(index);
    }
}
