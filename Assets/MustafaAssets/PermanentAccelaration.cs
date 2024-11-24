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
        transform.position += Vector3.down * 3f * Time.deltaTime;
        if (transform.position.y <= -12f) Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "PlayerCar"){
            RoadGenerator.EnvironmentSpeed *= AccelerationCoefficient; 
        }
    }
}
