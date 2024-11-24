using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryAccelaration : MonoBehaviour
{
    [SerializeField]
    private float TemporarySpeedCoEfficient = 2;
    
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "PlayerCar"){
            StartCoroutine(Accelator());
        }
    }
    IEnumerator Accelator(){
        RoadGenerator.EnvironmentSpeed *= TemporarySpeedCoEfficient;
        yield return new WaitForSeconds(5f);
        RoadGenerator.EnvironmentSpeed /= TemporarySpeedCoEfficient; 
    }
}
