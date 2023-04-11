using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Track : MonoBehaviour
{
    public enum CompetitorsState
    {
        Preparation,
        Race,
        Result
    }
    
    private List<double> _xPosition = new List<double>();    

    [SerializeField] private List<GameObject> _startPoints = new List<GameObject>();
    [SerializeField] private List<Competitor> _competitors;
    [SerializeField] private Bookmaker _bookmaker;
    [SerializeField] private Finish _finish;

    public CompetitorsState CurrentState { get; private set; }
    public List<Competitor> Competitors => _competitors;

    private void Start()
    {        
        CurrentState = CompetitorsState.Preparation;
    }

    private void Update()
    {
        RaceState();
    }

    private void OnEnable()
    {
        _finish.StateChanged += FinishState;
    }

    private void OnDisable()
    {
        _finish.StateChanged -= FinishState;
    }

    private void RaceState()
    {
        if (CurrentState == CompetitorsState.Preparation)
        {
            StartPosition();
            CompetitorsStartSpeed(0);
        }

        if (CurrentState == CompetitorsState.Race)
        {
            CompetitorsChangingSpeed();
            CheckPosition();
        }

        if (CurrentState == CompetitorsState.Result)
        {
            CompetitorsStartSpeed(0);
        }
    }

    private void CompetitorsStartSpeed(int speed)
    {
        for (int i = 0; i < Competitors.Count; i++)
        {
            Competitors[i].IdleSpeed(speed);
        }
    }

    private void CompetitorsChangingSpeed()
    {
        for (int i = 0; i < Competitors.Count; i++)
        {
            Competitors[i].RunSpeed();
        }
    }

    private void CheckPosition()
    {
        for (int i = 0; i < Competitors.Count; i++)
        {
            _xPosition.Add(Competitors[i].transform.position.x);
        }

        _xPosition.Sort();

        for (int i = 0; i < _xPosition.Count; i++)
        {
            for (int j = 0; j < Competitors.Count; j++)
            {
                if (_xPosition[i] == Competitors[j].transform.position.x)
                {
                    Competitors[j].PositionSet(_xPosition.Count - i);
                }
            }            
        }

        _xPosition.Clear();
    }

    public void StartPosition()
    {
        for (int i = 0; i < Competitors.Count; i++)
        {
            Competitors[i].transform.position = new Vector3(_startPoints[i].transform.position.x, _startPoints[i].transform.position.y);
            Competitors[i].NumberChosenSet(i + 1);
        }
    }

    public void StartRace()
    {
        if (CurrentState == Track.CompetitorsState.Preparation && _bookmaker.CompetitorChosen != null && _bookmaker.BetMade > 0)
        {
            CurrentState = Track.CompetitorsState.Race;
        }
    }

    public void FinishState()
    {
        CurrentState = Track.CompetitorsState.Result;
    }

    public void NewRaceButton()
    {
        if (CurrentState == Track.CompetitorsState.Result)
        {
            CurrentState = Track.CompetitorsState.Preparation;
            Time.timeScale = 1f;
        }
    }
}
