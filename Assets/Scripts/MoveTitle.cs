using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTitle : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * Speed));
    }
}
