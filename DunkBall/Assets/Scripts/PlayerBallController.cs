using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    [SerializeField] private ParticleSystem groundContactParticle;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float force = 3;

    private Rigidbody ballRigidbody;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = targetPoint.position - transform.position;
            ballRigidbody.velocity = direction.normalized * force;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            ballRigidbody.velocity += Vector3.up * 7;
            groundContactParticle.transform.position = collision.contacts[0].point;
            groundContactParticle.Play();
        }
    }
}
