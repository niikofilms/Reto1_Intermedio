using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    public ControladorDePausa juegoPausado;

    private void Start()
    {
        juegoPausado = GetComponent<ControladorDePausa>();
    }

    public void CambiarEscenaJuego (string juego)
    {
        juegoPausado.juegoPausado = false;
        SceneManager.LoadScene(juego);
    }

    public void CambiarEscenaMenu (string menuPrincipal)
    {
        SceneManager.LoadScene(menuPrincipal);
    }
   
}
