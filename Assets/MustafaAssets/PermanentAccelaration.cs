using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentAccelaration : MonoBehaviour
{
    [SerializeField]
    private float AccelerationCoefficient = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "PlayerCar"){
            RoadGenerator.EnvironmentSpeed *= AccelerationCoefficient; 
        }
    }
}
