using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickUp : MonoBehaviour, IDamageable
{
    public int NumberOfFlowers { get; private set; }

    public UnityEvent<ItemPickUp> OnFlowerUpdated;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            FlowersDropped();
    }
    public void FlowersCollected()
    {
        NumberOfFlowers++;
        OnFlowerUpdated.Invoke(this);
    }

    public void FlowersDropped()
    {
        if (NumberOfFlowers > 0)
        {
            NumberOfFlowers--;
            OnFlowerUpdated?.Invoke(this);
        }       
    }

    public void AllFlowersDropped()
    {
        if (NumberOfFlowers > 0)
        {
            NumberOfFlowers = 0;
            OnFlowerUpdated?.Invoke(this);
        }
    }

    public void TakeDamage()
    {
        FlowersDropped();
    }
}
