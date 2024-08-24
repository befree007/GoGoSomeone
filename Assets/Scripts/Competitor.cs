using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Competitor : MonoBehaviour
{
    private float _speed;
    private int _positionNumber;
    private int _numberChosen;
    private double _winCounter;
    private double _loseCounter;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private int _minTimeIndex;
    [SerializeField] private int _maxTimeIndex;
    [SerializeField] private float _minRangeSpeed;
    [SerializeField] private float _maxRangeSpeed;
    [SerializeField] private Track _track;
    [SerializeField] private Finish _finish;

    private const string _runAnimation = "Run";
    private const string _idleAnimation = "Idle";
    private const double _constantCoefficient = 3;
    private const double _divider = 10;

    public double CurrentCoefficient { get; private set; }
    public float Speed => _speed;
    public int PositionNumber => _positionNumber;
    public int NumberChosen => _numberChosen;
    public double WinCounter => _winCounter;
    public double LoseCounter => _loseCounter;    

    private void Start()
    {
        CurrentCoefficient = _constantCoefficient;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (_speed != 0)
        {
            _animator.Play(_runAnimation);
        }
        else
        {
            _animator.Play(_idleAnimation);
        }

        _rigidbody.velocity = new Vector2(_speed, 0);
    }

    public void IdleSpeed(int speed)
    {
        _speed = speed;
    }

    public void RunSpeed()
    {
        int timeIndex = Random.Range(_minTimeIndex, _maxTimeIndex);

        if (timeIndex == 1)
        {
            float rndSpeed = (float)Random.Range(_minRangeSpeed, _maxRangeSpeed);
            _speed = rndSpeed;
        }
    }

    public void PositionSet(int position)
    {
        _positionNumber = position;
    }

    public void NumberChosenSet(int number)
    {
        _numberChosen = number;
    }

    public void WinChanging(int winCounter)
    {
        _winCounter += winCounter;        
    }

    public void LoseChanging(int loseCounter)
    {
        _loseCounter += loseCounter;
    }

    public void CoefficientCount()
    {
        CurrentCoefficient = _constantCoefficient - _winCounter / _divider + _loseCounter / _divider;
    }
}
