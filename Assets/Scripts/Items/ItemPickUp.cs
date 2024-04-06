using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickUp : MonoBehaviour
{
   public int NumberOfFlowers { get; private set; }

    public UnityEvent<ItemPickUp> OnFlowerCollected;

    public void FlowersCollected()
    {
        NumberOfFlowers++;
        OnFlowerCollected.Invoke(this);
    }
}
