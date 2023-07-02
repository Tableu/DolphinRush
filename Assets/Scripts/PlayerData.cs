using UnityEngine;
[CreateAssetMenu(menuName = "Data/Player", fileName = "Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float angle;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;

    public float Speed => speed;
    public float MaxSpeed => maxSpeed;
    public float RotationSpeed => rotationSpeed;
    public float Angle => angle;
    public float MaxHeight => maxHeight;
    public float MinHeight => minHeight;
}
