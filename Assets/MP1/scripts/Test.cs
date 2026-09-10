using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public InputActionReference quitAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quitAction.action.Enable();
        quitAction.action.performed += (ctx) =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
