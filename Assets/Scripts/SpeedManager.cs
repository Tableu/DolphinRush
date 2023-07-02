using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private static SpeedManager _instance;

    public static SpeedManager Instance => _instance;

    [SerializeField] private SpeedData data;
    private int _speedLevel = 0;
    public int SpeedLevel => _speedLevel;

    public float SpeedMultiplier
    {
        get;
        private set;
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public IEnumerator StartSpeed()
    {
        for (int i = 0; i < data.Speeds.Count; i++)
        {
            SpeedMultiplier = data.Speeds[i];
            _speedLevel = i;
            SpeedChanged?.Invoke();
            yield return new WaitForSeconds(data.Durations[i]);
        }
    }

    public Action SpeedChanged;
}
