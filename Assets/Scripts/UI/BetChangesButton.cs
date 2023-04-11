using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetChangesButton : MonoBehaviour
{
    [SerializeField] private Track _track;
    [SerializeField] private Bookmaker _bookmaker;

    public void BetChoosing()
    {
        if (_track.CurrentState == Track.CompetitorsState.Preparation)
        {
            int index = Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text);
            _bookmaker.BetChanging(index);
        }
    }
}
