using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Data/Obstacles", fileName = "Obstacles")]
public class ObstacleData : ScriptableObject
{
    [SerializeField] private List<Obstacle> obstacles;
    [SerializeField] private List<int> weights;
    [SerializeField] private List<int> speedLevelIndexes;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float maxDistance;
    public float InitialSpeed => initialSpeed;
    public float MaxSpeed => maxSpeed;

    public Obstacle GetRandomObstacle(int speedLevel)
    {
        List<int> intervals = new List<int>();
        int totalWeight = 0;
        for(int i = 0; i < speedLevelIndexes[speedLevel]; i++)
        {
            totalWeight += weights[i];
            intervals.Add(totalWeight);
        }
        
        float randomNumber = Random.Range(0, totalWeight);
        int index = 0;
        foreach (int interval in intervals)
        {
            if (randomNumber < interval)
            {
                return obstacles[index];
            }

            index++;
        }
        return obstacles[0];
    }

    public float GetRandomDistance()
    {
        return Random.Range(minimumDistance, maxDistance);
    }
}

[Serializable]
public class Obstacle
{
    public GameObject Prefab;
    public Vector3 Offset;
}