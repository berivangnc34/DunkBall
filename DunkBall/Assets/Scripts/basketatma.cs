using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketatma : MonoBehaviour
{
    public Transform throwpoint; //atıcı ilk konumu
    public Transform target;    //atıcı hedefi 
    public GameObject ball;     //fırlatılacak nesne
    public float timeToHit = 1f;
    float gravity;


    float throwTimer;
    public float timeBtwThrows;
    public float rotationSpeed = 1f;

    Transform thisTransform;



    
    void Start()
    {
        throwTimer= timeBtwThrows;
        gravity = Mathf.Abs(Physics.gravity.y);
        thisTransform = transform;
        
    }

   
    void Update()
    {
        Vector3 direction = target.position - thisTransform.position;
        direction.y = 0f;
        thisTransform.rotation = Quaternion.LookRotation(direction * (rotationSpeed * Time.deltaTime));

        if (throwTimer <= 0)
        {
            throwTimer = timeBtwThrows;
            Throw ();
        }
        else
        {
            throwTimer = Time.deltaTime;
        }

        

        
    }
    public void Throw()
    {
        Vector3 requiredVelocity = RequiredInitialVelocity(throwpoint.position, target.position, timeToHit);

        GameObject tempProjectile = Instantiate(ball, throwpoint.position, Quaternion.Euler(new Vector3(0,0,0)));

        Rigidbody rb = tempProjectile.GetComponent<Rigidbody>();

        rb.velocity = requiredVelocity;
        rb.AddTorque(tempProjectile.transform.forward * 900f);


        
    }

    Vector3 RequiredInitialVelocity(Vector3 throwPoint ,Vector3 target, float time)
    {
        Vector3 distance = target - throwPoint;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        float Vxz = (Sxz / time);
        float Vy = (Sy / time + .5f * gravity * time);
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
