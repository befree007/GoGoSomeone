using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationText : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _informationsText;
    [SerializeField] private Track _track;

    private void Update()
    {
        ShowCompetitorData();
    }

    public void ShowCompetitorData()
    {
        if (_track.CurrentState == Track.CompetitorsState.Preparation)
        {
            for (int i = 0; i < _informationsText.Count; i++)
            {
                _informationsText[i].gameObject.SetActive(true);
                _informationsText[i].text = $"Victories: {_track.Competitors[i].WinCounter}; Loses: {_track.Competitors[i].LoseCounter}; " +
                    $"Coefficient: {_track.Competitors[i].CurrentCoefficient}; Line: {_track.Competitors[i].NumberChosen}.";
            }            
        }
        else if (_track.CurrentState == Track.CompetitorsState.Race)
        {
            for (int i = 0; i < _informationsText.Count; i++)
            {
                _informationsText[i].gameObject.SetActive(false);
            }
        }
    }
}
