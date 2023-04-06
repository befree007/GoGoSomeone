using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
    [SerializeField] private BookmakerManager _bookmakerManager;
    [SerializeField] private TrackManager _trackManager;

    public void StartRace()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation && _bookmakerManager.CompetitorChosen != null && _bookmakerManager.BetMade > 0)
        {
            _trackManager.CurrentState = TrackManager.CompetitorsState.Race;
        }        
    }

    public void Bet()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation && _bookmakerManager.BetChanges > 0)
        {
            if (_bookmakerManager.BetChanges > _bookmakerManager.Balance)
            {
                _bookmakerManager.BetMade = _bookmakerManager.Balance;
            }
            else
            {
                _bookmakerManager.BetMade = _bookmakerManager.BetChanges;
                _bookmakerManager.Balance -= _bookmakerManager.BetMade;
                
            }

            _bookmakerManager.BetChanges = 0;
        }
    }

    public void Decrease10()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation)
        {
            _bookmakerManager.BetChanges -= 10;
        }        
    }

    public void Decrease1()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation)
        {
            _bookmakerManager.BetChanges -= 1;
        }        
    }

    public void Increase10()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation)
        {
            _bookmakerManager.BetChanges += 10;
        }
    }

    public void Increase1()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation)
        {
            _bookmakerManager.BetChanges += 1;
        }
    }

    public void ChoseCompetitor()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Preparation)
        {
            int index = Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text);
            Debug.Log(index);
            _trackManager.Competitors[index - 1].NumberChosen = index;
            _bookmakerManager.CompetitorChosen = _trackManager.Competitors[index - 1];
        }
    }

    public void NewRace()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Result)
        {
            _trackManager.CurrentState = TrackManager.CompetitorsState.Preparation;
        }
    }
}
