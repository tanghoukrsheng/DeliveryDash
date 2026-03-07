using UnityEngine;
using UnityEngine.InputSystem;  
using TMPro;  // for TextMeshProUGUI if needed

public class Drive : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;      // degrees per second
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float boostSpeed = 10f;  // additional speed when boost is active
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] TMP_Text boostText;  // reference to UI text element to display speed
   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         // nothing to initialize yet
    }
 void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            Debug.Log("Boost activated  ");
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);  // show boost text
            Destroy(collision.gameObject);
        }
    }
        

 void OnCollisionEnter2D(Collision2D collision)
    {
            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);  // hide boost text
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

        float moveAmount = moveInput * currentSpeed * Time.deltaTime;
        float steerAmount = steerInput * steerSpeed * Time.deltaTime;

        // move along local Y axis (forward)
        transform.Translate(0, moveAmount, 0);
        // rotate around Z for top‑down view; change to Vector3.up if using 3D car
        transform.Rotate(0, 0, steerAmount);
    }
}
