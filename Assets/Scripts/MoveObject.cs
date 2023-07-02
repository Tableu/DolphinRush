using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        var position = transform1.position;
        transform.position = Vector3.MoveTowards(position,
            new Vector3(-60, position.y, position.z), Speed * Time.deltaTime);
        //transform.Translate(Vector3.left * (Speed * Time.deltaTime),Space.World);
        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }
}
