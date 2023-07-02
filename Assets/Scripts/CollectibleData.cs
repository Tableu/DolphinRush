using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Collectibles", fileName = "Collectibles")]
public class CollectibleData : ScriptableObject
{
    [SerializeField] private List<GameObject> collectibles;
    [SerializeField] private List<int> weights;
    
    public GameObject GetRandomCollectible()
    {
        List<int> intervals = new List<int>();
        int totalWeight = 0;
        foreach(int weight in weights)
        {
            totalWeight += weight;
            intervals.Add(totalWeight);
        }
        
        float randomNumber = Random.Range(0, totalWeight);
        int index = 0;
        foreach (int interval in intervals)
        {
            if (randomNumber < interval)
            {
                return collectibles[index];
            }

            index++;
        }
        return collectibles[0];
    }
}
