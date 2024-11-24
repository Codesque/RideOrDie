using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestObstacle : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("PlayerCar")) { 
            
            Instantiate(explosion , collision.transform.position , Quaternion.identity);
            Destroy(collision.gameObject);
            RoadGenerator.EnvironmentSpeed = 0f;
        
        }



    }

    private void Update()
    {
        transform.position += Vector3.down * RoadGenerator.EnvironmentSpeed * Time.deltaTime;

        if (transform.position.y <= -12f) Destroy(this.gameObject);
    }




}
