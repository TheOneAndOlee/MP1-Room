using System;
using UnityEngine;
using Random = System.Random;

public class Comet : MonoBehaviour
{
    public Vector3 velocity;
    public float lifespan = 5.0f;
    public GameObject particlePrefab;
    public bool speedDefined = false;
    
    void Start()
    {
        // Random initial velocity
        if (!speedDefined)
        {
            velocity = new Vector3(UnityEngine.Random.Range(0.0f, 5.0f), 
                UnityEngine.Random.Range(0.0f, 5.0f), 
                UnityEngine.Random.Range(0.0f, 5.0f));
        }
        
        
    }

    private void Awake()
    {
        Destroy(gameObject, lifespan);
    }
    
    private void OnDestroy()
    {
        Debug.Log("Destroying Comet");
        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        particles.GetComponent<AudioSource>().Play();
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