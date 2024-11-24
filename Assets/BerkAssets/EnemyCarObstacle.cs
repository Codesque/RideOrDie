using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarObstacle : MonoBehaviour
{
    [Range(0f , 1f)]public float SlowPercentage;

    float _speed = 0f;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _speed = Mathf.Min(RoadGenerator.EnvironmentSpeed * (1f - SlowPercentage) , 1f);
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        Vector3 currentPos = _rb.position; 
        currentPos.y -= _speed * Time.deltaTime; 
        if(currentPos.y <= -12f)
            this.gameObject.SetActive(false);
        else _rb.position = currentPos;
        
    }
}
