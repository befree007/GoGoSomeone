using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogsText : MonoBehaviour
{
    public enum Dialogs
    {
        First,
        Second
    }

    [SerializeField] private GameObject _badGuyEmpji;
    [SerializeField] private GameObject _strangeGuyEmpji;
    [SerializeField] private TextMeshProUGUI _currentDialog;
    [SerializeField] private Button _continueButton;

    private Dialogs _dialogs;

    private const string _loadScene = "Game";

    private void Start()
    {
        _dialogs = Dialogs.First;
    }

    private void Update()
    {
        Dialog();
    }

    public void Dialog()
    {
        if (_dialogs == Dialogs.First)
        {
            _currentDialog.text = "<color=green>Player:</color> Bad day, I owed 1000 $ some criminal guy, but I have only 100 $. " +
            "\n<color=red>Bad Guy:</color> Hey, where did you disappear to? I need my money!!!" +
            "\n<color=green>Player:</color>: Swear, I will return the debt. Give me a few more days!" +
            "\n<color=red>Bad Guy:</color> Okey, I will come to you every 7 days and take 100 $ from you until you pay your debt. However if you can't pay, I will kill you!";
        }
        else if (_dialogs == Dialogs.Second)
        {
            _currentDialog.text = "<color=yellow>Strange Guy:</color> Hello, why are you so sad?" +
            "\n<color=green>Player:</color> Hi, I must earn 1000 $ for several days." +
            "\n<color=yellow>Strange Guy:</color> I tell you a secret. We organize illegal races for cosplayers. You can bet on someone of them and win or lose!" +
            "\n<color=green>Player:</color>: It is so ricky, but i have no choice. Let's do it!";
        }
    }

    public void OnButtonClick()
    {
        if (_dialogs == Dialogs.First)
        {
            _dialogs = Dialogs.Second;
            _badGuyEmpji.SetActive(false);
            _strangeGuyEmpji.SetActive(true);
        }
        else if (_dialogs == Dialogs.Second)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(_loadScene, LoadSceneMode.Single);
        }
    }
}
