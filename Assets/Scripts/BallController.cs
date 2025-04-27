using System;
using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Transform rouletteCenter,ballTransform;
    public float startRadius = 2f;
    public float endRadius = 0.5f;
    public float spinSpeed = 360f;
    public float maxDeceleration = 100f;
    
    public float baseSpeed = 100f;
    public float minStopSpeed = 10f;
    public float slowDownThreshold = 25f;   
    
    public AudioSource rollSound;              
    public AudioSource tickSound;              
    
    private float currentAngle = 0f;
    private float currentSpeed = 0f;
    private float currentRadius;
    private bool isSpinning = false;
    private bool isStopping = false;
    private float targetAngle;
    
    public event Action OnBallComplete;

    void Start()
    {
        currentRadius = startRadius;
    }

    void FixedUpdate()
    {
        if (!isSpinning) return;

        currentAngle += currentSpeed * Time.fixedDeltaTime;
        currentAngle = (currentAngle + 360f) % 360f;

        if (!isStopping)
        {
            currentSpeed = Mathf.Max(0, currentSpeed - maxDeceleration * Time.fixedDeltaTime);
        }
        else
        {
            float angleDiff = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));
            
            if (angleDiff > slowDownThreshold)
            {
                currentSpeed = baseSpeed;
            }
            else
            {
                float t = angleDiff / slowDownThreshold;
                currentSpeed = Mathf.Lerp(minStopSpeed, baseSpeed, t);
            }
            currentAngle += currentSpeed * Time.fixedDeltaTime;
            currentAngle %= 360f;
            currentRadius = Mathf.Lerp(currentRadius, endRadius, Time.fixedDeltaTime * 2f);
            if (angleDiff < 0.2f)
            {
                isStopping = false;
                isSpinning = false;
                currentSpeed = 0f;
                //rollSound?.Stop();
                OnBallComplete?.Invoke();
            }
        }
        
        float tiltAmount = Mathf.Clamp(currentSpeed / spinSpeed, 0f, 1f) * 15f;
        ballTransform.rotation = Quaternion.Euler(tiltAmount, -currentAngle, 0f);
        Vector3 offset = new Vector3(Mathf.Cos(currentAngle * Mathf.Deg2Rad), 0, Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * currentRadius;
        ballTransform.position = rouletteCenter.position + offset;
    }

    public void StartSpinning()
    {
        currentSpeed = spinSpeed;
        currentRadius = startRadius;
        isSpinning = true;
        isStopping = false;
        //rollSound?.Play();
    }

    public void StopToTarget(Transform targetPoint)
    {
        Vector3 dir = (targetPoint.position - rouletteCenter.position).normalized;
        targetAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        isStopping = true;
    }
}
