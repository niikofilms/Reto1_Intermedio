using UnityEngine;
using UnityEngine.UI;


public class ApareceCherry : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    private int dotsCollected = 0;
    public int dotsToCollect = 15;

    void Start()
    {
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dot"))
        {
            Destroy(other.gameObject);
            dotsCollected++;
            UpdateScoreText();

            if (dotsCollected >= dotsToCollect)
            {
                if (winText != null)
                {
                    scoreText.text = "¡Ganaste!";
                }
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
