using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bookmaker : MonoBehaviour
{
    [SerializeField] private double _debt;
    [SerializeField] private double _balance;
    [SerializeField] private double _secondChanceBalance;
    [SerializeField] private double _betMade;
    [SerializeField] private double _betChanges;
    [SerializeField] private double _fixPayment;
    [SerializeField] private int _dayCount;
    [SerializeField] private int _dayPayment;
    [SerializeField] private Competitor _competitorChosen = null;
    [SerializeField] private Track _track;

    [SerializeField] private TextMeshProUGUI _betMadeText;
    [SerializeField] private TextMeshProUGUI _betChangeText;
    [SerializeField] private TextMeshProUGUI _dayCountText;
    [SerializeField] private TextMeshProUGUI _debtText;
    [SerializeField] private TextMeshProUGUI _balanceText;
    [SerializeField] private TextMeshProUGUI _competitorChosenText;
    [SerializeField] private GameObject _paymentPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _secondChancePanel;

    private bool _secondChance = true;

    public double Debt => _debt;
    public double Balance => _balance;
    public double SecondChanceBalance => _secondChanceBalance;
    public double BetMade => _betMade;
    public double BetChanges => _betChanges;
    public double FixPayment => _fixPayment;
    public int DayCount => _dayCount;
    public int DayPayment => _dayPayment;
    public Competitor CompetitorChosen => _competitorChosen;

    private void Update()
    {
        TextData();
        CheckDayPayment();
    }

    public void TextData()
    {
        _dayCountText.text = $"Day: {_dayCount}";
        _debtText.text = $"Debt: {_debt} $";
        _balanceText.text = $"Balance: {_balance} $";
        _betMadeText.text = $"Block: {_betMade} $";
        _betChangeText.text = $"Bet: {_betChanges} $";

        if (_competitorChosen != null)
        {
            _competitorChosenText.text = $"Competitor: {_competitorChosen.NumberChosen}";
        }
        else
        {
            _competitorChosenText.text = $"Competitor: 0";
        }
    }

    public void CheckDayPayment()
    {
        if (_track.CurrentState == Track.CompetitorsState.Result && _dayCount > _dayPayment)
        {
            Time.timeScale = 0f;
            _paymentPanel.SetActive(true);
            _dayCount = 1;
        }        
    }

    public void Zeroing()
    {
        _dayCount += 1;
        _betMade = 0;
        _betChanges = 0;
        _competitorChosen = null;

        for (int i = 0; i < _track.Competitors.Count; i++)
        {
            _track.Competitors[i].NumberChosenSet(0);
        }
    }

    public void WinMoney(Competitor competitor)
    {
        if (_competitorChosen == competitor)
        {
            _balance += _betMade * competitor.CurrentCoefficient;
        }

        CheckSecondChance();
    }

    public void CheckSecondChance()
    {
        if (_balance <= 0 && _secondChance == true)
        {
            _balance = _secondChanceBalance;
            _secondChancePanel.SetActive(true);
            _secondChance = false;
        }
        else if (_balance <= 0)
        {
            _gameOverPanel.SetActive(true);
        }
    }

    public void TryPayment()
    {
        if (_balance >= _fixPayment)
        {
            _debt -= _fixPayment;
            _balance -= _fixPayment;
            _paymentPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _gameOverPanel.SetActive(true);
        }
    }

    public void ChoseCompetitor(int index)
    {
        if (_track.CurrentState == Track.CompetitorsState.Preparation)
        {
            _competitorChosen = _track.Competitors[index - 1];
        }
    }

    public void Bet()
    {
        if (_track.CurrentState == Track.CompetitorsState.Preparation && _betChanges > 0)
        {
            if (_betChanges > _balance)
            {
                _betMade = _balance;
            }
            else
            {
                _betMade = _betChanges;
                _balance -= _betMade;
            }

            _betChanges = 0;
        }
    }

    public void BetChanging(int betChanges)
    {
        _betChanges += betChanges;
    }
}
