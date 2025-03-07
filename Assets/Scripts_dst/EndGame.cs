using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject endGamePanel;
    public Button replayButton;
    public Button menuButton;

    private void Start()
    {
        endGamePanel.SetActive(false);
        replayButton.onClick.AddListener(ReplayGame);
        menuButton.onClick.AddListener(GoToMenu);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("¡Juego terminado!");
            EndGame();
        }
    }

    void EndGame()
    {
        endGamePanel.SetActive(true);
    }

    void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("EscenaMenu");
    }
}