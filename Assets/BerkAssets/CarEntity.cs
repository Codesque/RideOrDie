using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarEntity : MonoBehaviour
{

    Camera cam;
    [SerializeField] private int MaxSpeed;
    [SerializeField] private int MaxAcc;
    [SerializeField] private float MaxAngularSpeed;
    //[SerializeField] private float minDistanceBrake = 4f;
    [SerializeField] private float minAngle = -30f;
    [SerializeField] private float maxAngle = 30f;
    [SerializeField] private bool IsCarSlownDown =false;
    [SerializeField] private float carBrakeCoefficient = 0.05f;
    Ray cursorRay;
    Rigidbody2D rb;
    Coroutine slownDownCoroutine;

    public Vector3 PlayerOrigin { get { return rb.position + Vector2.up * 3f; } }



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void SeekBehaviour(Vector3 currentPos , Vector3 target) {
        Vector3 velocity = (target - currentPos);
        if (velocity.sqrMagnitude > MaxSpeed * MaxSpeed)  
            velocity = velocity.normalized * MaxSpeed;
        
        transform.position += velocity * Time.deltaTime;
    
    }


    void DynamicSeekBehaviour(Vector3 currentPos, Vector3 target) {

        Vector3 dist = (target - currentPos);

        // Acceleration for the car
        Vector3 deltaVelocity = dist/(Time.deltaTime * Time.deltaTime);


        if (deltaVelocity.sqrMagnitude > MaxAcc * MaxAcc)
            deltaVelocity = deltaVelocity.normalized * MaxAcc;

        rb.velocity += (Vector2)deltaVelocity * Time.deltaTime;
        if (rb.velocity.sqrMagnitude > MaxSpeed * MaxSpeed) 
            rb.velocity = rb.velocity.normalized * MaxSpeed; 




    
    }

    IEnumerator SlowDown() {

        
            rb.velocity *= carBrakeCoefficient; 
            yield return new WaitForSeconds(0.375f);
            rb.velocity *= carBrakeCoefficient; 
            yield return new WaitForSeconds(0.375f);
            rb.velocity = Vector2.zero;
        

        

    
    }

    void StartSlowDown() {

        if (slownDownCoroutine == null) {

            slownDownCoroutine = StartCoroutine(SlowDown());
            Debug.Log("Hello");
        }
            
            
                
         
            
            
    
    }




    void DynamicFaceBehaviour(float targetAngle) { 
    
        float currentAngle = transform.rotation.eulerAngles.z;
        float clampedTargetAngle = Mathf.Clamp(targetAngle, -30, 30);

        float AngleSpeed = Mathf.Abs(clampedTargetAngle - currentAngle);
        if(Mathf.Abs(AngleSpeed) > MaxAngularSpeed) AngleSpeed = MaxAngularSpeed * Mathf.Sign(AngleSpeed); 



        transform.localRotation = Quaternion.RotateTowards(
            transform.localRotation , 
            Quaternion.Euler(0f,0f,targetAngle),
            AngleSpeed * Time.deltaTime
            );
    
    }



    void DynamicFaceBehaviour(Vector3 currentPos , Vector3 target) {
        Vector3 dir = (target - currentPos).normalized;
        float currentAngle = transform.rotation.eulerAngles.z;
        float oriBasedOnCursor = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;

        // -30 - 30 :: 60 120
        float targetAngle = ( oriBasedOnCursor < -160 || oriBasedOnCursor > 160) ? 0f : Mathf.Clamp(oriBasedOnCursor, minAngle, maxAngle);
        Debug.Log(targetAngle);



        float AngleSpeed = Mathf.Abs((targetAngle - currentAngle)/Time.deltaTime);
        if(AngleSpeed > MaxAngularSpeed) AngleSpeed = MaxAngularSpeed;


        transform.localRotation = Quaternion.RotateTowards(transform.localRotation , Quaternion.Euler(0f,0f,targetAngle) , AngleSpeed * Time.deltaTime);



        /*
        Vector3 ori = transform.rotation.eulerAngles;
        ori.z = targetAngle;
        transform.eulerAngles = ori;
        */
    }










    private void FixedUpdate()
    {

        if (IsCarSlownDown) { DynamicFaceBehaviour(0); StartSlowDown(); }
        else
        {
            DynamicFaceBehaviour(rb.position, cursorRay.origin);
            DynamicSeekBehaviour(rb.position, cursorRay.origin);
        }


    }



    // Update is called once per frame
    void Update()
    {
        cursorRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(cursorRay.origin, cursorRay.direction);
        if (hit && hit.collider.gameObject.name == "CarEntity") { IsCarSlownDown = true;return; }
        IsCarSlownDown = false;
        if (slownDownCoroutine != null) {

            StopCoroutine(slownDownCoroutine); 
            slownDownCoroutine = null;
        }
        //SeekBehaviour(transform.position, ray.origin);

    }
}
