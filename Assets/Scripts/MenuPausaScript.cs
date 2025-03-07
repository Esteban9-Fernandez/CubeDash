using System;
using UnityEngine;

public class MenuPausaScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    private bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

public void Pausar()
{
    isGamePaused = true;
    Time.timeScale = 0f;
    PauseMenu.SetActive(true);
    Cursor.visible = true;
}

    public void Reanudar()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void VolverMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
