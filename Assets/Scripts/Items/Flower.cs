using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public static Action OnFlowerCollected;

    private void OnTriggerEnter(Collider other)
    {
        ItemPickUp inventory = other.GetComponent<ItemPickUp>();

        if (inventory != null)
        {
            // This is for sound effect
            OnFlowerCollected?.Invoke();

            inventory.FlowersCollected();
            gameObject.SetActive(false);
        }
    }
}
