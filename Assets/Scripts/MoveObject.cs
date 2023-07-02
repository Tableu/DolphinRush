using System;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float Speed;

    private void Start()
    {
        SpeedManager.Instance.SpeedChanged += ChangeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        var position = transform1.position;
        transform.position = Vector3.MoveTowards(position,
            new Vector3(-70, position.y, position.z), Speed * Time.deltaTime);
        //transform.Translate(Vector3.left * (Speed * Time.deltaTime),Space.World);
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
}
