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


    private void Update()
    {
        transform.position += Vector3.down * 3f * Time.deltaTime;
        if (transform.position.y <= -12f) Destroy(this.gameObject);
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
