using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class startscherm : MonoBehaviour
{
    public InputAction start;
    private void OnEnable()
    {
        start.Enable();
    }

    private void OnDisable()
    {
        start.Enable();
    }
    void Update()
    {
        if (start.IsPressed())
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
