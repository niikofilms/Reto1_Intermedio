using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDePausa : MonoBehaviour
{
    public bool juegoPausado = false;
    public GameObject pauseUI;
    public string escenaActual;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Pausar el juego al presionar la tecla P
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
    public void ResetScene()
    {
        // Obtiene el índice de la escena actual y la recarga
        Time.timeScale = 1;
        juegoPausado = false;
        SceneManager.LoadScene(escenaActual);
    }
}
