using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveObject : MonoBehaviour
{
    public float Speed;
    public Vector3 Offset;
    [SerializeField] private List<Vector3> collectiblePositions;
    [SerializeField] private CollectibleData data;

    private void Start()
    {
        SpeedManager.Instance.SpeedChanged += ChangeSpeed;
        if (collectiblePositions.Count > 0)
        {
            int index = Random.Range(0, collectiblePositions.Count+1);
            if (index <= 0)
                return;
            Vector3 pos = collectiblePositions[index-1];
            var collectiblePrefab = data.GetRandomCollectible();
            var collectibleObject = Instantiate(collectiblePrefab, transform.position+pos-Offset, collectiblePrefab.transform.rotation);
            collectibleObject.GetComponent<Collectible>().Speed = Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        var position = transform1.position;
        transform.position = Vector3.MoveTowards(position,
            new Vector3(-70, position.y, position.z), Speed * Time.deltaTime);
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
