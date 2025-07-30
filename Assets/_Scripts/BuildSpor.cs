using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 15;
    private bool isBuilt = false;

    void OnMouseDown()
    {
        if (isBuilt) return;

        if (GoldManager.Instance.SpendGold(towerCost))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isBuilt = true;
        }
        else
        {
            Debug.Log("Yetersiz altın.");
        }
    }
}