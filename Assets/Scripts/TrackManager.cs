using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public enum CompetitorsState
    {
        Preparation,
        Race,
        Result
    }

    public List<Competitor> Competitors = new List<Competitor>();
    
    private List<double> _xPosition = new List<double>();    

    [SerializeField] private List<GameObject> _startPoints = new List<GameObject>();
    [SerializeField] private int _minTimeIndex;
    [SerializeField] private int _maxTimeIndex;
    [SerializeField] private float _minRangeSpeed;
    [SerializeField] private float _maxRangeSpeed;

    public CompetitorsState CurrentState { get; set; }

    private void Start()
    {        
        CurrentState = CompetitorsState.Preparation;
    }

    private void Update()
    {
        RaceState();        
        Debug.Log(CurrentState);
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

    public void CompetitorsStartSpeed(int speed)
    {
        for (int i = 0; i < Competitors.Count; i++)
        {
            Competitors[i].Speed = speed;
        }
    }

    public void CompetitorsChangingSpeed()
    {
        int timeIndex = Random.Range(_minTimeIndex, _maxTimeIndex);

        if (timeIndex == 1)
        {
            for (int i = 0; i < Competitors.Count; i++)
            {
                float rnd = (float)Random.Range(_minRangeSpeed, _maxRangeSpeed);
                Competitors[i].Speed = rnd;
            }
        }        
    }

    public void CheckPosition()
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
                    Competitors[j].PositionNumber = _xPosition.Count - i;
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
            Competitors[i].NumberChosen = i + 1;
        }
    } 
}
