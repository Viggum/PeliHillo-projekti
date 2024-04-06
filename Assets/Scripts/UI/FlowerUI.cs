using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerUI : MonoBehaviour
{
    private TextMeshProUGUI flowerText;

    void Start()
    {
        flowerText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFlowerText(ItemPickUp itemPickUp)
    {
        flowerText.text = itemPickUp.NumberOfFlowers.ToString();
    }

}
