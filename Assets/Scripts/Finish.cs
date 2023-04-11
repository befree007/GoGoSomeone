using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishScene;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private Bookmaker _bookmaker;
    [SerializeField] private Track _track;

    private List<Competitor> _competitorPosition = new List<Competitor>();

    public UnityAction StateChanged;

    private const int _resultChanging = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Competitor competitor))
        {
            _competitorPosition.Add(collision.gameObject.GetComponent<Competitor>());

            if (collision.gameObject.GetComponent<Competitor>().PositionNumber == 1)
            {
                collision.gameObject.GetComponent<Competitor>().WinChanging(_resultChanging); 
            }
            else
            {
                collision.gameObject.GetComponent<Competitor>().LoseChanging(_resultChanging);
            }

            if (_competitorPosition.Count == _track.Competitors.Count)
            {
                Debug.Log("Finish");
                StateChanged?.Invoke();
                _bookmaker.WinMoney(_competitorPosition[0]);
                UpdateCoefficient();
                _finishScene.SetActive(true);
                ShowResult();
                _bookmaker.Zeroing();
                _competitorPosition.Clear();
            }
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
