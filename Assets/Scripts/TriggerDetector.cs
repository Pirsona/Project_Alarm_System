using System;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public event Action<bool> ThiefIsEnter;

    private bool isEnter;

    private void OnTriggerEnter(Collider other)
    {
        CheckTrigger(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        CheckTrigger(other, false);
    }

    private void CheckTrigger(Collider other, bool IsEnter)
    {
        if (other.gameObject.TryGetComponent(out ThiefController controller))
        {
            ThiefIsEnter?.Invoke(IsEnter);
        }
    }
}