using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationText : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _informationsText;
    [SerializeField] private Track _trackManager;

    private void Update()
    {
        ShowCompetitorData();
    }

    public void ShowCompetitorData()
    {
        if (_trackManager.CurrentState == Track.CompetitorsState.Preparation)
        {
            for (int i = 0; i < _informationsText.Count; i++)
            {
                _informationsText[i].gameObject.SetActive(true);
                _informationsText[i].text = $"Victories: {_trackManager.Competitors[i].WinCounter}; Loses: {_trackManager.Competitors[i].LoseCounter}; " +
                    $"Coefficient: {_trackManager.Competitors[i].CurrentCoefficient}; Line: {_trackManager.Competitors[i].NumberChosen}.";
            }            
        }
        else if (_trackManager.CurrentState == Track.CompetitorsState.Race)
        {
            for (int i = 0; i < _informationsText.Count; i++)
            {
                _informationsText[i].gameObject.SetActive(false);
            }
        }
    }
}
