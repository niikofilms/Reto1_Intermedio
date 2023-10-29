using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DotsCollection : MonoBehaviour
{
    public int contador;
    public TMP_Text score;

    public void Awake()
    {
        contador = 0;
        score.text = "Dots: " + contador;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.tag == "Dot")
        {
            Debug.Log("Dot recogido");
            contador = contador + 1;
            score.text = "Dots: " + contador;
            Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }
}
