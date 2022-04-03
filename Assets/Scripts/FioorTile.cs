using UnityEngine;

public class FioorTile : MonoBehaviour
{

    FloorSpawner floorSpawner;

    [SerializeField]
    GameObject[] obstaclePrefab;

    [SerializeField]
    GameObject[] spawners;

    [SerializeField]
    GameObject collectablePrefab;

    [SerializeField]
    GameObject[] collectableSpawners;

    // Start is called before the first frame update
    void Start()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
        SpawnObstacle();

        if(Random.Range(0,3) == 0)
        {
            SpawnCollectable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            floorSpawner.SpawnTile();
            Destroy(gameObject, 5);
        }
    }
    
    void SpawnObstacle()
    {

        int index = Random.Range(0, spawners.Length);
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);


        Transform spawnPoint = spawners[index].transform;

        Instantiate(obstaclePrefab[obstacleIndex], new Vector3(spawnPoint.position.x, obstaclePrefab[obstacleIndex].transform.position.y, spawnPoint.position.z), Quaternion.identity,transform);
    }

    void SpawnCollectable()
    {

        int index = Random.Range(0, collectableSpawners.Length);


        Transform spawnPoint = collectableSpawners[index].transform;

        Instantiate(collectablePrefab, new Vector3(spawnPoint.position.x, collectablePrefab.transform.position.y, spawnPoint.position.z), Quaternion.identity, transform);
    }
}
