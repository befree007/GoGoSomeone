using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Competitor : MonoBehaviour
{
    public float Speed;
    public int PositionNumber;
    public int NumberChosen;
    public double WinCounter;
    public double LoseCounter;

    public const double ConstantCoefficient = 3;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public double CurrentCoefficient { get; private set; }

    private void Start()
    {
        CurrentCoefficient = ConstantCoefficient;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Speed != 0)
        {
            _animator.Play("Run");
        }
        else
        {
            _animator.Play("Idle");
        }

        _rigidbody.velocity = new Vector2(Speed, 0);
    }

    public void CoefficientCount()
    {
        CurrentCoefficient = ConstantCoefficient - WinCounter / 10 + LoseCounter / 10;
    }
}
