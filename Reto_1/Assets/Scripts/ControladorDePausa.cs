using UnityEngine;

public class ControladorDePausa : MonoBehaviour
{
    private bool juegoPausado = false;
    public GameObject pauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Pausar el juego al presionar la tecla Escape
        {
            if (juegoPausado)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0; // Pausar el tiempo del juego
        juegoPausado = true;
    }

    void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1; // Reanudar el tiempo del juego
        juegoPausado = false;
    }

    public void ResumePauseGame()
    {
        if (juegoPausado)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }    
    }
}
