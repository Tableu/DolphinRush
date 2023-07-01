using UnityEngine;
[CreateAssetMenu(menuName = "Data/Player", fileName = "Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float angle;

    public float Speed => speed;
    public float MaxSpeed => maxSpeed;
    public float RotationSpeed => rotationSpeed;
    public float Angle => angle;
}
