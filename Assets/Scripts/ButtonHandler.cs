using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{


    [SerializeField] private Button victoryButton;
    [SerializeField] private Button defeatButton;

       private void Awake()
    {

        // Make sure button is linked
        victoryButton.onClick.AddListener(OnContinue);
        defeatButton.onClick.AddListener(OnContinue);


    }

    public void OnContinue()
    {
        Time.timeScale = 1f; // resume
        SceneManager.LoadScene("SampleScene");
    }

}
