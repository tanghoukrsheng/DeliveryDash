using UnityEngine;
using UnityEngine.InputSystem;  

public class Drive : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;      // degrees per second
    [SerializeField] float moveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // nothing to initialize yet
    }

    // Update is called once per frame
    void Update()
    {
        float steerInput = 0f;   // -1 left, +1 right
        float moveInput = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            moveInput = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            moveInput = -1f;
        }
        else
        {
            moveInput = 0f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steerInput = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steerInput = -1f;
        }

        float moveAmount = moveInput * moveSpeed * Time.deltaTime;
        float steerAmount = steerInput * steerSpeed * Time.deltaTime;

        // move along local Y axis (forward)
        transform.Translate(0, moveAmount, 0);
        // rotate around Z for top‑down view; change to Vector3.up if using 3D car
        transform.Rotate(0, 0, steerAmount);
    }
}
