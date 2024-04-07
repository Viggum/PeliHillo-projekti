using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSafeSpace : MonoBehaviour
{
    public static Action OnPlayerEntered;
    public static Action OnPlayerExited;

    private void OnTriggerEnter(Collider other)
    {
        var testPlayer = other.GetComponent<CharacterController>();
        if (testPlayer != null)
            OnPlayerEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        var testPlayer = other.GetComponent<CharacterController>();
        if (testPlayer != null)
            OnPlayerExited?.Invoke();
    }
}
