using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Camera mainCamera;
    public float despawnDistance = 5f;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (mainCamera != null)
        {
            float distanceX = Mathf.Abs(transform.position.x - mainCamera.transform.position.x);
            
            if (distanceX >= despawnDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
