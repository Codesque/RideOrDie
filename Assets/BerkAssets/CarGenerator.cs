using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    [SerializeField] private float HowMuchTimePerCarSpawn;
    [SerializeField] private float TimeOffset;
    [SerializeField] private float HowMuchPeriodBeforeIncrement;
    [SerializeField] private float MinTimePerCarSpawn = 0.1f;
    [SerializeField] private float initialSlowPercentage = 0.9f;
    [SerializeField] private float SlowPercentageDecrement = 0.1f;
    CarPool pool;
    float _lastTime;
    int periodCount = 0;

    private void Start()
    {
        pool = GameObject.FindFirstObjectByType<CarPool>();
        HowMuchTimePerCarSpawn = UnityEngine.Random.Range(7f, 25f);
        _lastTime =   TimeOffset - HowMuchTimePerCarSpawn;
    }

    private void Update()
    {
        if (_lastTime + HowMuchTimePerCarSpawn <= Time.time) {
            
            pool.GetRandomCar(transform.position , initialSlowPercentage);
            periodCount++;
            _lastTime = Time.time;
        
        }


        if (periodCount >= HowMuchPeriodBeforeIncrement) {
            HowMuchTimePerCarSpawn = Mathf.Max(HowMuchTimePerCarSpawn * 0.9f, MinTimePerCarSpawn);
            initialSlowPercentage = Mathf.Max(0.1f, initialSlowPercentage - SlowPercentageDecrement);
            SlowPercentageDecrement = Mathf.Max(0.05f, SlowPercentageDecrement * 0.7f);
            periodCount = 0;   
        
        }

        

    }



}
