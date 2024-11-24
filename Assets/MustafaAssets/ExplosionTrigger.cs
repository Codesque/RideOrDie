using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject ExplosionController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onTriggerEnter2D(Collider2D other){
        if(other.tag == "PlayerCan"){
            Instantiate(ExplosionController,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
