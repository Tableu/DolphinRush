using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Speed", fileName = "Speed")]
public class SpeedData : ScriptableObject
{
    [SerializeField] private List<float> speeds;
    [SerializeField] private List<float> durations;

    public List<float> Speeds => speeds;
    public List<float> Durations => durations;
}
