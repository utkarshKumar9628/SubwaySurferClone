using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speedObstacle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * speedObstacle );
    }

    private void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}
