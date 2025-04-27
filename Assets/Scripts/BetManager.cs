using System;
using TMPro;
using UnityEngine;

public class BetManager : MonoBehaviour
{
    private BetType Type;
    private int Number; // Sadece Single için kullanılır
    private int Amount;
    private int CurrentBet;
    public TextMeshProUGUI singleInfoTMP, amountInfoTMP, winingInfoTMP, userInfoTMP, betTypeTMP;
    private int userAmount = 0;

    public void RestartPage()
    {
        betTypeTMP.text = "Current Bet Type :";
        singleInfoTMP.text = "Selected Number : ";
        amountInfoTMP.text = "Current Bet Amount : ";
        CurrentBet = 0;
        Amount = 0;
        Number = 0;
    }

    public void SetBetType(int betType)
    {
        Type = (BetType)betType;
        betTypeTMP.text = "Current Bet Type :" + Type.ToString();
    }

    public void SetNumber(int number)
    {
        Number = number;
        singleInfoTMP.text = "Selected Number : " + Number;
    }

    public void AmountIncrease()
    {
        Amount += CurrentBet;
        amountInfoTMP.text = "Current Bet Amount : " + Amount.ToString();
    }

    public void AmountDecrease()
    {
        if (Amount - CurrentBet >= 0)
        {
            Amount -= CurrentBet;
            amountInfoTMP.text = "Current Bet Amount : " + Amount.ToString();
        }
    }

    public void SetCurrentBet(int currentBet)
    {
        CurrentBet = currentBet;
    }

    public int GetBetType()
    {
        return (int)Type;
    }

    public int GetBetAmount()
    {
        return Amount;
    }

    public int EvaluateBets(int winningNumber)
    {
        winingInfoTMP.text = winningNumber.ToString();

        if (userAmount >= Amount) userAmount -= Amount;

        if (IsWinningBet(winningNumber))
        {
            int multiplier = GetPayoutMultiplier(Type);
            userAmount += Amount;
            userAmount += Amount * multiplier;
        }

        userInfoTMP.text = userAmount.ToString();
        return userAmount;
    }

    private bool IsWinningBet(int result)
    {
        switch (Type)
        {
            case BetType.Single: return Number == result;
            case BetType.Red: return IsRed(result);
            case BetType.Black: return IsBlack(result);
            case BetType.Even: return result != 0 && result % 2 == 0;
            case BetType.Odd: return result % 2 == 1;
            case BetType.Low: return result >= 1 && result <= 18;
            case BetType.High: return result >= 19 && result <= 36;
            case BetType.Dozen1: return result >= 1 && result <= 12;
            case BetType.Dozen2: return result >= 13 && result <= 24;
            case BetType.Dozen3: return result >= 25 && result <= 36;
            default: return false;
        }
    }

    private int GetPayoutMultiplier(BetType type)
    {
        switch (type)
        {
            case BetType.Single: return 35;
            case BetType.Dozen1: return 2;
            case BetType.Dozen2: return 2;
            case BetType.Dozen3: return 2;
            case BetType.Red: return 1;
            case BetType.Black: return 1;
            case BetType.Even: return 1;
            case BetType.Odd: return 1;
            case BetType.Low: return 1;
            case BetType.High: return 1;
            default: return 0;
        }
    }


    private bool IsRed(int number)
    {
        int[] reds = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        return System.Array.Exists(reds, n => n == number);
    }

    private bool IsBlack(int number)
    {
        int[] blacks = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        return System.Array.Exists(blacks, n => n == number);
    }
}

[Serializable]
public enum BetType
{
    Single = 0,
    Red = 1,
    Black = 2,
    Even = 3,
    Odd = 4,
    Low = 5,
    High = 6,
    Dozen1 = 7,
    Dozen2 = 8,
    Dozen3 = 9
}