using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstacleData data;
    private GameObject _mostRecentObstacle;
    private float _distance;
    private float _speedMultiplier = 1;
    private void Start()
    {
       SpawnObstacle();
       SpeedManager.Instance.SpeedChanged += delegate
       {
           _speedMultiplier = SpeedManager.Instance.SpeedMultiplier;
       };
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
        var obstacleObject = Instantiate(obstacle.Prefab, transform.position+obstacle.Offset, obstacle.Prefab.transform.rotation);
        var objectScript = obstacleObject.GetComponent<MoveObject>();
        objectScript.Speed = data.InitialSpeed*_speedMultiplier;
        _mostRecentObstacle = obstacleObject;
        _distance = data.GetRandomDistance() + Mathf.Abs(obstacle.Offset.x);
    }
}
