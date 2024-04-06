using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropOff : MonoBehaviour
{
    [SerializeField] private BaseManager baseManager;

    private void OnTriggerEnter(Collider other)
    {
        ItemPickUp test = other.GetComponent<ItemPickUp>();
        if (test != null)
        {
            baseManager.SetFlowers(test.NumberOfFlowers);
            test.AllFlowersDropped();
        }
            


    }
}
