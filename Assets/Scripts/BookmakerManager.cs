using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookmakerManager : MonoBehaviour
{
    public string PlayerName;
    public double Debt;
    public double Balance;
    public double SecondChanceBalance;
    public double BetMade;
    public double BetChanges;
    public double FixPayment;
    public int DayCount;
    public int DayPayment;
    public Competitor CompetitorChosen = null;

    [SerializeField] private TextMeshProUGUI _betMadeText;
    [SerializeField] private TextMeshProUGUI _betChangeText;
    [SerializeField] private TextMeshProUGUI _dayCountText;
    [SerializeField] private TextMeshProUGUI _debtText;
    [SerializeField] private TextMeshProUGUI _balanceText;
    [SerializeField] private TextMeshProUGUI _competitorChosenText;
    [SerializeField] private GameObject _paymentPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _secondChancePanel;
    [SerializeField] private TrackManager _trackManager;

    private bool _secondChance = true;

    private void Update()
    {
        TextData();
        CheckDayPayment();
    }

    public void TextData()
    {
        _dayCountText.text = $"Day: {DayCount}";
        _debtText.text = $"Debt: {Debt} $";
        _balanceText.text = $"Balance: {Balance} $";
        _betMadeText.text = $"Block: {BetMade} $";
        _betChangeText.text = $"Bet: {BetChanges} $";

        if (CompetitorChosen != null)
        {
            _competitorChosenText.text = $"Competitor: {CompetitorChosen.NumberChosen}";
        }
        else
        {
            _competitorChosenText.text = $"Competitor: 0";
        }
    }

    public void CheckDayPayment()
    {
        if (DayCount > DayPayment)
        {
            Time.timeScale = 0f;
            _paymentPanel.SetActive(true);
            DayCount = 1;
        }
    }

    public void Zeroing()
    {
        BetMade = 0;
        BetChanges = 0;
        CompetitorChosen = null;

        for (int i = 0; i < _trackManager.Competitors.Count; i++)
        {
            _trackManager.Competitors[i].NumberChosen = 0;
        }
    }

    public void WinMoney(Competitor competitor)
    {
        if (CompetitorChosen == competitor)
        {
            Balance += BetMade * competitor.CurrentCoefficient;
        }

        CheckSecondChance();
    }

    public void CheckSecondChance()
    {
        if (Balance <= 0 && _secondChance == true)
        {
            Balance = SecondChanceBalance;
            _secondChancePanel.SetActive(true);
            _secondChance = false;
        }
        else if (Balance <= 0)
        {
            _gameOverPanel.SetActive(true);
        }
    }

    public void TryPayment()
    {
        if (Balance >= FixPayment)
        {
            Debt -= FixPayment;
            Balance -= FixPayment;
            _paymentPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _gameOverPanel.SetActive(true);
        }
    }
}
