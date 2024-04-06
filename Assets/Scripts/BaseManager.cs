using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    // Maybe change this to trigger
    [SerializeField] private Transform dropoffPos;

    private int baseLevel = 0;
    [SerializeField] private int maxLevel = 1;

    [SerializeField] private int currentFlowers = 0;
    [SerializeField] private int[] flowersToLevelUp;

    // Señor cactus can't come inside the safe area
    [SerializeField] private float safeArea = 20f;

    [SerializeField] private GameObject[] baseLevelBuildings;
    [SerializeField] private Transform baseBuildingPos;
    [SerializeField] private GameObject currentBuilding;

    public GameObject smokeVFX;

    public TextMeshProUGUI flowersAmountText;

    public void levelUp()
    {
        baseLevel++;

        Destroy(currentBuilding);

        upgradeBuilding();        
    }

    public void upgradeBuilding()
    {
        Instantiate(smokeVFX, baseBuildingPos.position, Quaternion.identity);
        // TODO: Add smoke effect on bulding upgrade
        currentBuilding = Instantiate(baseLevelBuildings[baseLevel - 1], baseBuildingPos.position, Quaternion.identity, transform);
    }

    public void SetFlowers(int flowerAmount)
    {       
        currentFlowers += flowerAmount;
        flowersAmountText.text = currentFlowers.ToString() + "/" + flowersToLevelUp[baseLevel].ToString();

        // If there is enough flowers in the base, level up
        if(currentFlowers >= flowersToLevelUp[baseLevel] && baseLevel != maxLevel)
        {
            currentFlowers -= flowersToLevelUp[baseLevel];
            levelUp();
            flowersAmountText.text = currentFlowers.ToString() + "/" + flowersToLevelUp[baseLevel].ToString();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(dropoffPos.position, 2f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, safeArea);
    }
}
