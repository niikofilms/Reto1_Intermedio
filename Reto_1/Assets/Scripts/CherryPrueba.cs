using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CherryPrueba : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text winText;
    private int dotsCollected = 0;
    public int dotsTarget = 15;
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

            if (dotsCollected == dotsTarget)

            {
                cherryObject.SetActive(true);

            }
        }
        
        if (other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);
            
            if (winText != null)
            {
                winText.text = "¡Ganaste!";
            }
        }
    }

   
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + dotsCollected.ToString();
        }
    }
}

