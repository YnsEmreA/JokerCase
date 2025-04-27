using System;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public BallController ballController;
    public WheelController wheelController;
    public BetManager betManager;
    public TargetSelector targetSelector;
    public UIManager uiManager;
    Number targetNumber;
    
    private void Start()
    {
        wheelController.OnSpinComplete += HandleWheelStopped;
        ballController.OnBallComplete += CheckBet;
        uiManager.SetMainUserMoney(0);
    }

    public void StartSpin()
    {
        targetNumber = targetSelector.GetTargetNumber();
        uiManager.SetMainSelectedNumber(targetNumber.targetNumber);
        uiManager.SetMainBetAmount(betManager.GetBetAmount());
        wheelController.StartSpin();
        ballController.StartSpinning();
    }

    private void HandleWheelStopped()
    {
        ballController.StopToTarget(targetNumber.targetTransform);
    }

    private void CheckBet()
    {
        uiManager.OpenResultPage();
        int currentAmount = betManager.EvaluateBets(targetNumber.targetNumber);
        uiManager.SetMainBetType((BetType)betManager.GetBetType());
        uiManager.SetMainUserMoney(currentAmount);
    }

    public void Restart()
    {
        betManager.RestartPage();
        targetSelector.RestartPage();
    }
}
