using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelController : MonoBehaviour
{
    public Transform rouletteTransform;
    public float minSpinSpeed = 500f;
    public float maxSpinSpeed = 1000f;
    public float deceleration = 150f;
    private bool isSpinning = false;
    public event Action OnSpinComplete;
    
    public void StartSpin()
    {
        float startSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
        StartCoroutine(SpinRoulette(startSpeed));
    }
    
    private IEnumerator SpinRoulette(float startSpeed)
    {
        isSpinning = true;
        float currentSpeed = startSpeed;

        while (currentSpeed > 0)
        {
            rouletteTransform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            currentSpeed -= deceleration * Time.deltaTime;
            yield return null;
        }
        isSpinning = false;
        OnSpinComplete?.Invoke();
    }
}