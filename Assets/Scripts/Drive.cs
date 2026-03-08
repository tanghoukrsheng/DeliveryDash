using UnityEngine;
using UnityEngine.InputSystem;  


public class Drive : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;      // degrees per second
    [SerializeField] float currentSpeed =8f;
    [SerializeField] float boostSpeed = 4f;  // additional speed when boost is active
    [SerializeField] float regularSpeed = 8f;
    
    [SerializeField] AudioSource sfxBoost; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
 void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            Debug.Log("Boost activated  ");
            currentSpeed += boostSpeed;
            Destroy(collision.gameObject);
            sfxBoost.Play();
        }
    }
        

 void OnCollisionEnter2D(Collision2D collision)
    {
            currentSpeed = regularSpeed;
    }

    

    // Update is called once per frame
    void Update()
    {
        float steerInput = 0f;   // -1 left, +1 right
        float moveInput ;

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

        float moveAmount = moveInput * currentSpeed * Time.deltaTime;
        float steerAmount = steerInput * steerSpeed * Time.deltaTime;

        // move along local Y axis (forward)
        transform.Translate(0, moveAmount, 0);
        // rotate around Z for top‑down view; change to Vector3.up if using 3D car
        transform.Rotate(0, 0, steerAmount);
    }


}
