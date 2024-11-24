using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPool : MonoBehaviour
{

    public EnemyCarObstacle[] carTypes;
    public int CarAmountPerType = 10;

    EnemyCarObstacle[] pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new EnemyCarObstacle[carTypes.Length * CarAmountPerType ];
        for (int i = 0; i < pool.Length; i++) {

            pool[i] = Instantiate(carTypes[i % carTypes.Length] , transform);
            pool[i].gameObject.SetActive(false);
        
        }
    }

    public EnemyCarObstacle GetRandomCar(Vector3 position , float slowPercentage) {

        int randIdx = UnityEngine.Random.Range(0, pool.Length/2);

        for (int i = randIdx; i < pool.Length; i++) {

            if (!pool[i].gameObject.activeSelf) {
                pool[i].SlowPercentage = slowPercentage;
                pool[i].transform.position = position;
                pool[i].gameObject.SetActive(true);
                return pool[i];
            
            }
       
           
        }

        return null;
    
    
    }
}
