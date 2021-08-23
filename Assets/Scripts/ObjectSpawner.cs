using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private float spawnDistanceInterval;

    private float distanceCounter;
    private int lastIndex = -1;

    //Spawn an object just above the screen
    private void SpawnObject()
    {
        // No object is spawned twice in a row
        int spawnIndex = Random.Range(0, spawnObjects.Length);
        while(spawnIndex == lastIndex)
        {
            spawnIndex = Random.Range(0, spawnObjects.Length);
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth*0.5f, Camera.main.pixelHeight + 300, 0));
        GameObject obj = Instantiate(spawnObjects[spawnIndex], new Vector3(pos.x, pos.y , 0), transform.rotation);
        lastIndex = spawnIndex;
        distanceCounter = spawnDistanceInterval;
    }

    //Tracks when to spawn a new object, this method is called each time the camera moves
    public void DecreaseDistance(float amount)
    {
        distanceCounter -= amount;
        if (distanceCounter <= 0)
        {
            SpawnObject();
        }
    }

}
