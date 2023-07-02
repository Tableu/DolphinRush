using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstacleData data;
    private GameObject _mostRecentObstacle;
    private float _distance;

    private void Start()
    {
       SpawnObstacle();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_mostRecentObstacle.transform.position.x - transform.position.x) > _distance)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        var obstacle = data.GetRandomObstacle();
        var obstacleObject = Instantiate(obstacle.Prefab, transform.position+obstacle.Offset, Quaternion.identity);
        var objectScript = obstacleObject.GetComponent<MoveObject>();
        objectScript.Speed = data.InitialSpeed;
        _mostRecentObstacle = obstacleObject;
        _distance = data.GetRandomDistance() + (-1)*obstacle.Offset.x;
    }
}