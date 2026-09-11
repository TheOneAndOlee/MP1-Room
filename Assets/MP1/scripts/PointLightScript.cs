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
    public void ChangeColor()
    {

        light.color = new Color(UnityEngine.Random.Range(0.2f, 1f), UnityEngine.Random.Range(0.2f, 1f), UnityEngine.Random.Range(0.2f, 1f), UnityEngine.Random.Range(0.75f, 1f));
        foreach (AudioSource a in GetComponents<AudioSource>())
        {
            if (!a.loop)
            {
                a.Play();
            }
        }
        ParticleSystem.MainModule mm = GetComponent<ParticleSystem>().GetComponent<ParticleSystem>().main;
        mm.startColor = light.color;
        GetComponent<ParticleSystem>().Stop();
        GetComponent<ParticleSystem>().Play();
    }
    
}
