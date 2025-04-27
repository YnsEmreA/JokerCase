using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public List<Number> numbers = new List<Number>();
    private Number targetNumber;
    public TextMeshProUGUI infoTMP;

    public void SetTarget(int number)
    {
        targetNumber = numbers.Find(n => n.targetNumber == number);
        infoTMP.text = "Selected Number : " + targetNumber.targetNumber.ToString();
    }

    public void RestartPage()
    {
        infoTMP.text = "Selected Number : ";
    }
    public Number GetTargetNumber()
    {
        if (targetNumber != null)
        {
            return targetNumber;
        }
        else
        {
            return numbers[Random.Range(0, numbers.Count)];
        }
    }
}
