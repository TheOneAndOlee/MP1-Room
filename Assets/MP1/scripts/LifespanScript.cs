using UnityEngine;

public class LifespanScript : MonoBehaviour
{
    [SerializeField] private float lifespan = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
