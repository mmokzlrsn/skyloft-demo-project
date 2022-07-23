 using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float XspawnRange = 2.5f;

    private float ZnextPos = 0;
    private float ZspawnRange = 10f;
    private float ZspawnRangeMax = 20f;

    private int obstacleCount = 5;




    void Start()
    {
        for(int i = 0 ; i < obstacleCount; i++ )
        {
            SpawnObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, GenerateSpawnPos(), obstaclePrefab.transform.rotation);

    }

    private Vector3 GenerateSpawnPos()
    {
          
        float spawnPosX = Random.Range(-XspawnRange, XspawnRange);
        float spawnPosZ = Random.Range(ZnextPos + ZspawnRange, ZnextPos + ZspawnRangeMax);
        ZnextPos = ZnextPos + ZspawnRangeMax;

        return new Vector3(spawnPosX,  1, spawnPosZ);
    }
}
