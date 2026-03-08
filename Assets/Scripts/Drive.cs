using UnityEngine;
using UnityEngine.InputSystem;  


public class Drive : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;      // degrees per second
    [SerializeField] float currentSpeed = 4f;
    [SerializeField] float boostSpeed = 2f;  // additional speed when boost is active
    //[SerializeField] float regularSpeed = 4f;
    
    [SerializeField] AudioSource sfxBoost; 
    [SerializeField] AudioSource sfxBump; 

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        Time.timeScale = 1f;
    }
 void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            Debug.Log("Boost activated  ");
            if(currentSpeed< 16) currentSpeed += boostSpeed; // Increase speed by boost amount, but cap it at 16
            Destroy(collision.gameObject);
            sfxBoost.Play();
        }
    }
        

 void OnCollisionEnter2D(Collision2D collision)
    {
           Debug.Log("Bump detected"+collision.gameObject.name); // Print the name of the object that triggered the collision
           sfxBump.Play();
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
