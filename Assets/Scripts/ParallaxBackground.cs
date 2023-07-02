using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script that moves materials on a quad to create a infinite moving parallax background.
/// Materials must use unlit transparent shaders
/// </summary>
public class ParallaxBackground : MonoBehaviour
{
    public List<Vector2> scrollSpeed;

    private Renderer _renderer;

    public bool EnableBackground = true;
    private float _speedMultiplier = 1;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        SpeedManager.Instance.SpeedChanged += ChangeSpeed;
    }

    void Update()
    {
        Material[] backgrounds = _renderer.materials;
        if (backgrounds != null && EnableBackground)
        {
            int max = Mathf.Min(backgrounds.Length, scrollSpeed.Count);
            for (int index = 0; index < max; index++)
            {
                Vector2 offset = new Vector2(Time.time * scrollSpeed[index].x*_speedMultiplier, Time.time * scrollSpeed[index].y);
                _renderer.materials[index].mainTextureOffset = offset;
            }
        }
    }

    private void ChangeSpeed()
    {
        _speedMultiplier = SpeedManager.Instance.SpeedMultiplier;
    }

    private void OnDisable()
    {
        SpeedManager.Instance.SpeedChanged -= ChangeSpeed;
    }
}