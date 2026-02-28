using UnityEngine;
using UnityEngine.InputSystem;  

public class Drive : MonoBehaviour
{

    [SerializeField]float steerspeed = 0.2f;
    [SerializeField]float moveSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        float steer = 0f;
        float move =0f;
        
         if (Keyboard.current.aKey.isPressed)
         {
             steerspeed = 0.25f;
         }
         else if (Keyboard.current.dKey.isPressed)
         {
             steerspeed = -0.25f;
         }
         else
         {
             steerspeed = 0f;
         }


         transform.Rotate(0, 0, steerspeed);
         transform.Translate(0, moveSpeed, 0);

    }
}
