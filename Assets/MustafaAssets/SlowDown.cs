using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    float baslangicHizi;
    bool isOnSoil;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
            if(other.tag == "PlayerCar"){
                isOnSoil = true;
                baslangicHizi = RoadGenerator.EnvironmentSpeed;
                StartCoroutine(SlowingDown());
            }
        }
    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "PlayerCar"){
            isOnSoil = false;
            RoadGenerator.EnvironmentSpeed = baslangicHizi;
        }
    }

    IEnumerator SlowingDown(){ 
        while(isOnSoil == true){
            if(RoadGenerator.EnvironmentSpeed < 5f) RoadGenerator.EnvironmentSpeed = 0;
            else RoadGenerator.EnvironmentSpeed = RoadGenerator.EnvironmentSpeed*0.8f;
            yield return new WaitForSeconds(0.9f);
    }
    }
}
