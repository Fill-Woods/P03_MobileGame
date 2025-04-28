using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RooftopManager : MonoBehaviour
{
    public GameObject[] rooftopsPrefabs;
    public float zSpawn = 0;
    public float rooftopLength = 15;
    public int numberOfRooftops = 5;

    private List<GameObject> activeRooftops = new List<GameObject>();

    public Transform playerTransform;

    private int rooftopsSpawned = 0;

    private void Start()
    {
        for(int i=0; i<numberOfRooftops; i++)
        {
            if (i == 0)
                SpawnRooftops(1);
            else
                SpawnRooftops(Random.Range(1,rooftopsPrefabs.Length));
                
        }
    }
    private void Update()
    {
        if(playerTransform.position.z - 20 >zSpawn- (numberOfRooftops*rooftopLength))
        {
            if (rooftopsSpawned == 4)
            {
                SpawnRooftops(0);
                rooftopsSpawned = 0;
                
            }
            else
            {
                SpawnRooftops(Random.Range(1, rooftopsPrefabs.Length));
                rooftopsSpawned++;
                DeleteRooftops();

            }
        }
    }
    public void SpawnRooftops(int rooftopIndex)
    {
        GameObject go = Instantiate(rooftopsPrefabs[rooftopIndex],transform.forward * zSpawn, transform.rotation);
        activeRooftops.Add(go);
        zSpawn += rooftopLength;
    }
    private void DeleteRooftops()
    {
        Destroy(activeRooftops[0]);
        activeRooftops.RemoveAt(0);
    }
}
