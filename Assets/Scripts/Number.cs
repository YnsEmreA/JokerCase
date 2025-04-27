using System;
using UnityEngine;

public class Number : MonoBehaviour
{
    public int targetNumber;
    public Transform targetTransform
    {
        get { return this.transform; }
    }
}