using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "PlayerCar"){
            GameObject prefab = Instantiate(ExplosionController,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(prefab , 1f);
            RoadGenerator.EnvironmentSpeed = 0;
        }
    }
}
