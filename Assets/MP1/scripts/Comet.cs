using System;
using UnityEngine;
using Random = System.Random;

public class Comet : MonoBehaviour
{
    public Vector3 velocity;

    void Start()
    {
        // Random initial velocity
        velocity = new Vector3(UnityEngine.Random.Range(0.0f, 5.0f), 
                               UnityEngine.Random.Range(0.0f, 5.0f), 
                               UnityEngine.Random.Range(0.0f, 5.0f));
        
        
    }

    void Update()
    {
        Vector3 position = transform.position;

        const double gravity = 0.2;
        double distance = Math.Sqrt(Math.Pow(position.x, 2) + Math.Pow(position.y, 2) + Math.Pow(position.z, 2));
        double ax = -gravity * position.x / Math.Pow(distance, 3);
        double ay = -gravity * position.y / Math.Pow(distance, 3);
        double az = -gravity * position.z / Math.Pow(distance, 3);

        velocity.x = velocity.x + (float)(ax * Time.deltaTime);
        velocity.y = velocity.y + (float)(ay * Time.deltaTime);
        velocity.z = velocity.z + (float)(az * Time.deltaTime);

        transform.position += velocity * Time.deltaTime;
    }

}