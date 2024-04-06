using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    // Maybe change this to trigger
    [SerializeField] private Transform dropoffPos;

    private int baseLevel = 0;
    [SerializeField] private int maxLevel = 1;

    // Señor cactus can't come inside the safe area
    [SerializeField] private float safeArea = 20f;

    [SerializeField] private GameObject[] baseLevelBuildings;
    [SerializeField] private Transform baseBuildingPos;
    private GameObject currentBuilding;

    public GameObject smokeVFX;

    // Start is called before the first frame update
    void Start()
    {
        upgradeBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(baseLevel != maxLevel)
                levelUp();
        }
    }

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
        currentBuilding = Instantiate(baseLevelBuildings[baseLevel], baseBuildingPos.position, Quaternion.identity, transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(dropoffPos.position, 2f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, safeArea);
    }
}
