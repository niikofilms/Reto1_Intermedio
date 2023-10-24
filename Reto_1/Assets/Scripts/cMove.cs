using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMove : MonoBehaviour
{
    public Transform[] puntosRuta;
    public float velocidadMovimiento = 3f;
    private int indicePuntoActual = 0;
    private int direccion = 1;


    void Start()
    {
        StartCoroutine(MoverPorRuta());
    }

    IEnumerator MoverPorRuta()
    {
        while (true)
        {
            Vector3 siguientePunto = puntosRuta[indicePuntoActual].position;
            transform.LookAt(siguientePunto);

            while(transform.position != siguientePunto)
            {
                transform.position = Vector3.MoveTowards(transform.position, siguientePunto, velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            indicePuntoActual += direccion;

            if (indicePuntoActual >= puntosRuta.Length || indicePuntoActual < 0)
            {
                direccion *= -1;
                indicePuntoActual += direccion * 2;          
            }
           
        }
    }

}
