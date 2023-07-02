using UnityEngine;
[CreateAssetMenu(menuName = "Data/Player", fileName = "Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float angle;
    [SerializeField] private float rotateSpeed;

    public float Speed => speed;
    public float MaxSpeed => maxSpeed;
    public float Angle => angle;
    public float RotateSpeed => rotateSpeed;
}
