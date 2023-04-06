using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishScene;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private BookmakerManager _bookmakerManager;

    [SerializeField] protected TrackManager _trackManager;

    private List<Competitor> _competitorPosition = new List<Competitor>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Competitor competitor))
        {
            _competitorPosition.Add(collision.gameObject.GetComponent<Competitor>());

            if (collision.gameObject.GetComponent<Competitor>().PositionNumber == 1)
            {
                collision.gameObject.GetComponent<Competitor>().WinCounter += 1;
            }
            else
            {
                collision.gameObject.GetComponent<Competitor>().LoseCounter += 1;
            }

            if (_competitorPosition.Count == _trackManager.Competitors.Count)
            {
                Debug.Log("Finish");
                _trackManager.CurrentState = TrackManager.CompetitorsState.Result;
                _bookmakerManager.WinMoney(_competitorPosition[0]);
                UpdateCoefficient();
                _bookmakerManager.DayCount += 1;
                _finishScene.SetActive(true);
                ShowResult();
                _bookmakerManager.Zeroing();
                _competitorPosition.Clear();
            }
        }
    }

    public void NewRaceButton()
    {
        if (_trackManager.CurrentState == TrackManager.CompetitorsState.Result)
        {
            _trackManager.CurrentState = TrackManager.CompetitorsState.Preparation;
            Time.timeScale = 1f;
            _finishScene.SetActive(false);
        }
    }

    public void UpdateCoefficient()
    {
        for (int i = 0; i < _competitorPosition.Count; i++)
        {
            _competitorPosition[i].CoefficientCount();
        }
    }

    public void ShowResult()
    {
        _resultText.text = $"Winner: \n {_competitorPosition[0].name} - ¹ {_competitorPosition[0].NumberChosen}";
    }
}
