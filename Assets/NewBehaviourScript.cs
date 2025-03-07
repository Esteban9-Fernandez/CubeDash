using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena o reiniciar el nivel

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el personaje tiene el tag "Player"
        {
            Debug.Log("¡Nivel completado!");
            EndGame();
        }
    }

    void EndGame()
    {
        // Opción 1: Pausar el juego
        // Time.timeScale = 0;

        // Opción 2: Cargar el siguiente nivel (si tienes más niveles)
        // SceneManager.LoadScene("NombreDelSiguienteNivel");

        // Opción 3: Reiniciar el nivel actual
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
