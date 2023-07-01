using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Player", fileName = "Player")]
public class ObstacleData : ScriptableObject
{
    [SerializeField] private List<GameObject> obstacles;
    public List<GameObject> Obstacles => obstacles;
}
