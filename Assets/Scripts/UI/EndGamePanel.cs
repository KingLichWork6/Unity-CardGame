using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : UIPanel
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _deckBuildButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private TextMeshProUGUI _endGameText;

    [SerializeField] private TextMeshProUGUI _endGameWin;
    [SerializeField] private TextMeshProUGUI _endGameLose;
    [SerializeField] private TextMeshProUGUI _endGameDraw;
    [SerializeField] private TextMeshProUGUI _pauseText;

    private void OnEnable()
    {
        GameManager.HideEndGamePanel += Hide;

        _restartButton.onClick.AddListener(Restart);
        _deckBuildButton.onClick.AddListener(ToDeckBuild);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        GameManager.HideEndGamePanel -= Hide;

        _restartButton.onClick.RemoveListener(Restart);
        _deckBuildButton.onClick.RemoveListener(ToDeckBuild);
        _exitButton.onClick.RemoveListener(Exit);
    }

    public void EndGame(int playerPoints, int enemyPoint)
    {
        Show();

        if (playerPoints < enemyPoint)
        {
            _endGameText.text = _endGameLose.text;
        }

        else if (playerPoints > enemyPoint)
        {
            _endGameText.text = _endGameWin.text;
        }

        else
        {
            _endGameText.text = _endGameDraw.text;
        }
    }

    public void Pause()
    {
        Show();

        _endGameText.text = _pauseText.text;
    }

    private void Restart()
    {
        GameManager.Instance.NewGame();
    }

    private void ToDeckBuild()
    {
        GameManager.Instance.DeckBuild();
    }

    private void Exit()
    {
        GameManager.Instance.ToMenu();
    }
}
