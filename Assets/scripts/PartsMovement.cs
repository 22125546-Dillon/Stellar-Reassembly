using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectibleRotation : MonoBehaviour
{
    public float rotationSpeed = 60f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    } 
}
