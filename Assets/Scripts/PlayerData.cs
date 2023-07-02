using UnityEngine;
[CreateAssetMenu(menuName = "Data/Player", fileName = "Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float correctionSpeed;
    [SerializeField] private float idleCorrectionSpeed;
    [SerializeField] private float idleSpeed;
    [SerializeField] private float idleMaxSpeed;
    [SerializeField] private float angle;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float chargeTime;

    public float Speed => speed;
    public float MaxSpeed => maxSpeed;
    public float CorrectionSpeed => correctionSpeed;
    public float IdleCorrectionSpeed => idleCorrectionSpeed;
    public float IdleSpeed => idleSpeed;
    public float IdleMaxSpeed => idleMaxSpeed;
    public float Angle => angle;
    public float MaxHeight => maxHeight;
    public float MinHeight => minHeight;
    public float ChargeTime => chargeTime;
}
