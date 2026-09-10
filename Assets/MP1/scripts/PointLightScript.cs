using UnityEngine;

public class PointLightScript : MonoBehaviour
{
    public Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    public void OnToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            light.color = new Color(1, 0.2f, 0.3f, 1);
        }
    }
}
