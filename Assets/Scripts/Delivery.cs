using UnityEngine;
using TMPro;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField]float delayTime = 0.5f;
    [SerializeField] TMP_Text counterText;  // reference to UI text element to display speed
    [SerializeField] TMP_Text timerText;  // reference to UI text element to display speed
    [SerializeField] GameObject victoryScreen;  
    [SerializeField] GameObject defeatScreen;  
    private int currentCount = 0;
    private int maxCount = 3;  
    ParticleSystem particleSystemComponent;

    private int baseTimer = 180;  // 3 minutes in seconds
    private float currentTimer;
    void Start()
    {
    particleSystemComponent = GetComponent<ParticleSystem>();
    currentTimer = baseTimer;
    UpdateCounterDisplay();
    }

    void UpdateCounterDisplay()
    {
    counterText.text = $"{currentCount}/{maxCount}";  // or use: currentCount + "/" + maxCount
    if(currentCount >= maxCount)
    {
        PauseGameAndShowVictory();
    }
    }


    void IncreaseCounter()
    {
    currentCount++;
    UpdateCounterDisplay();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked up  ");
            hasPackage = true;
            particleSystemComponent.Play();
            Destroy(collision.gameObject, delayTime);
        }

        if(collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package  ");
            hasPackage = false;
            particleSystemComponent.Stop();
            Destroy(collision.gameObject);
            IncreaseCounter();
            }
        }

        void PauseGameAndShowVictory()
        {
        Time.timeScale = 0f;  // Pause the game
        victoryScreen.SetActive(true);  // Show victory panel
        Debug.Log("Victory! All packages delivered!");
        }

    void Update()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime; // Decrease timer by the time passed since last frame
            int minutes = (int)currentTimer / 60;
            int seconds = (int)currentTimer % 60;
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
        else
        {
            Time.timeScale = 0f;  // Pause the game
            defeatScreen.SetActive(true);  // Show defeat panel
        }
    }
}

