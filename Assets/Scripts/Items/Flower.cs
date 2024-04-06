using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemPickUp inventory = other.GetComponent<ItemPickUp>();

        if (inventory != null)
        {
            inventory.FlowersCollected();
            gameObject.SetActive(false);
        }
    }
}
