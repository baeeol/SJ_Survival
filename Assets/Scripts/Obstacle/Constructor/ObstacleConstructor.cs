using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

public class ObstacleConstructor : MonoBehaviour
{
    public GameObject[] dangerousObstaclesManagers;
    public GameObject[] CrowdControlObstaclesManagers;

    void Start()
    {
        StartCoroutine(startCreatingObstacle());
    }

    private IEnumerator startCreatingObstacle() {
        float INITIAL_CYCLE = 0.35f;
        float END_CYCLE = 0.07f;
        float cycle = INITIAL_CYCLE;
        float elapsedTime = 0f;

        while (true) {
            yield return new WaitForSeconds(cycle);

            // creating obstacle
            GameObject currentObstacleManager = GetCurrentObstacleManager();
            GameObject instantiatedObstacleManager = 
            Instantiate(currentObstacleManager, transform.position, Quaternion.identity, transform);
            SetRandomPosition(instantiatedObstacleManager);

            // reduce cycle
            if(cycle > END_CYCLE) {
                cycle = (float)(-1 * Math.Sqrt(0.001f * elapsedTime) + INITIAL_CYCLE);
                elapsedTime += cycle;
            }

            Debug.Log(cycle);
        }
    }

    private GameObject GetCurrentObstacleManager() {
        if(Random.Range(0f, 3.5f) > 1) {
            return dangerousObstaclesManagers[Random.Range(0, dangerousObstaclesManagers.Length)];
        } else {
            return CrowdControlObstaclesManagers[Random.Range(0, CrowdControlObstaclesManagers.Length)];
        };
    }

    private void SetRandomPosition(GameObject target) {
        Vector3 mapScale = GameObject.FindGameObjectWithTag("Map")
                            .GetComponent<BoxCollider>()
                            .bounds.size;
        
        float rangeBias = 2.5f;
        float randomX = Random.Range(-mapScale.x / rangeBias, mapScale.x / rangeBias);
        float randomZ = Random.Range(-mapScale.z / rangeBias, mapScale.z / rangeBias);
        Vector3 randomPositon = new Vector3(randomX, 0f, randomZ);

        target.transform.position = randomPositon;
    }
}
