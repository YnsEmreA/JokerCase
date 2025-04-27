using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject selectNumberPage, betPage, spinPage, resultPage;
    public TextMeshProUGUI selectedNumberTMP, userMoneyTMP, betTypeTMP, betAmountTMP;

    public void CheckBetType(BetManager betMan)
    {
        int betType = betMan.GetBetType();
        SetMainBetType((BetType)betType);
        if (betType == 0)
        {
            selectNumberPage.SetActive(true);
        }
        else
        {
            betPage.SetActive(true);
        }
    }

    public void OpenResultPage()
    {
        spinPage.SetActive(false);
        resultPage.SetActive(true);
    }

    public void SetMainSelectedNumber(int number)
    {
        selectedNumberTMP.text = "Selected Number : " + number.ToString();
    }

    public void SetMainUserMoney(int money)
    {
        userMoneyTMP.text = "User Money : " + money.ToString();
    }

    public void SetMainBetType(BetType type)
    {
        betTypeTMP.text = "Current Bet Type : " + type.ToString();
    }

    public void SetMainBetAmount(int amount)
    {
        betAmountTMP.text = "Current Bet Amount : " + amount.ToString();
    }
}