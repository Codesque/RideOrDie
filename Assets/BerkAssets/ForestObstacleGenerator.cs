using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestObstacleGenerator : MonoBehaviour
{

    [SerializeField] private List<ForestObstacle> forestObstacleTypes;
    private float GenerationPeriod;


    float _lastTime;

    private void Start()
    {
        GenerationPeriod = UnityEngine.Random.Range(2f, 10f);
    }


    // Update is called once per frame
    void Update()
    {

        if (_lastTime + GenerationPeriod < Time.time) { 
        
            int randNum = UnityEngine.Random.Range(0, forestObstacleTypes.Count);
            Instantiate(forestObstacleTypes[randNum] , transform.position, Quaternion.identity);
            GenerationPeriod = UnityEngine.Random.Range(2f, 10f);
            _lastTime = Time.time;
        }

    }
}
