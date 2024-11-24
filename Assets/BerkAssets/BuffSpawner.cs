using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{

    RoadGenerator[] roadGenerators;
    [SerializeField] private List<GameObject> buffPrefab;

    [SerializeField] private float PeriodTime;
    [SerializeField] private float MinPeriodTime;

    float _lastTime;


    // Start is called before the first frame update
    void Start()
    {
        roadGenerators = GameObject.FindObjectsOfType<RoadGenerator>();
        PeriodTime = UnityEngine.Random.Range(MinPeriodTime , 50f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastTime + PeriodTime < Time.time) {

            int randIdx = UnityEngine.Random.Range(0, buffPrefab.Count);
            int randSpawnIdx = UnityEngine.Random.Range(0, roadGenerators.Length);

            Instantiate(buffPrefab[randIdx], roadGenerators[randSpawnIdx].transform.position, Quaternion.identity); 


            _lastTime = Time.time;
        
        }


    }
}
