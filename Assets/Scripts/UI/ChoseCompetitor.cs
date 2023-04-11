using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoseCompetitor : MonoBehaviour
{
    [SerializeField] private Bookmaker _bookmaker;

    public void ChoseCompetitorButton()
    {
        int index = Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text);
        _bookmaker.ChoseCompetitor(index);
    }
}
