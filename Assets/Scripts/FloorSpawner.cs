using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] floorTile;
    Vector3 nextSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFirstTile();
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }

    }

    public void SpawnTile()
    {

        int index = Random.Range(0, floorTile.Length);

        GameObject temp = Instantiate(floorTile[index], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    public void SpawnFirstTile()
    {


        GameObject temp = Instantiate(floorTile[0], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

}
