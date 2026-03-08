using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

public static ButtonHandler Instance { get; private set; }
    [SerializeField] private Button victoryButton;
    [SerializeField] private Button defeatButton;

       private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        victoryButton.onClick.AddListener(OnContinue);
        defeatButton.onClick.AddListener(OnContinue);


    }

    public void OnContinue()
    {
        Time.timeScale = 1f; // resume
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("SampleScene");
    }

}
