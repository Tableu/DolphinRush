using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float Speed;

    private void Start()
    {
        SpeedManager.Instance.SpeedChanged += ChangeSpeed;
    }

    void Update()
    {
        var transform1 = transform;
        var position = transform1.position;
        transform.position = Vector3.MoveTowards(position,
            new Vector3(-70, position.y, position.z), Speed * Time.deltaTime);
        if (transform.position.x < -60)
        {
            Destroy(gameObject);
        }
    }

    private void ChangeSpeed()
    {
        Speed *= SpeedManager.Instance.SpeedMultiplier;
    }

    private void OnDisable()
    {
        SpeedManager.Instance.SpeedChanged -= ChangeSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
