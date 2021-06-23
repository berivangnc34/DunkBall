using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Vector3 appendDistance; //kameraya eklenecek mesafe

    private Vector3 targetPosition; 

    private void Awake()
    {
        transform.position = cameraTarget.position + appendDistance;
    }

    private void FixedUpdate()
    {
        targetPosition = new Vector3(cameraTarget.position.x, 0, cameraTarget.position.z) + appendDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * 2);
    }
}
