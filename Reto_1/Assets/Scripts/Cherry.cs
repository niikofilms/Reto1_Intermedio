using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Cherry : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text winText;
    private int dotsCollected = 0;
    public int dotsTarget = 2;
    public GameObject cherryObject;
    private bool gano = false;

    void Start()
    {
        UpdateScoreText();
        cherryObject.SetActive(false);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dot"))
        {
            Destroy(other.gameObject);
            dotsCollected++;
            UpdateScoreText();

            if (dotsCollected >= dotsTarget)
            {
                cherryObject.SetActive(true);

                if ( dotsTarget == 2 )
                { 
                    scoreText.text = "¡Ganaste!";
                    Debug.Log("Funciona");

                }  
               
            }

              



        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Dot") && (winText != null))
            
        {
     
            scoreText.text = "¡Ganaste!"; 
        }

    }
    */
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + dotsCollected.ToString();
        }
    }
}

