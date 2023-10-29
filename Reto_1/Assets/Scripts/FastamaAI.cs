using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FastamaAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float flySpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool flying, chasing;
    public Transform player;
    Transform currentDest;
    Vector3 dest;
    int randNum;
    public int destinationAmount;
    public Vector3 rayCastOffset;
    public string deathScene;

    void Start()
    {
        flying = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;

        // Comprueba si el enemigo ve al jugador
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            // Si lo ve, comienza a perseguirlo
            if(hit.collider.gameObject.tag == "Player")
            {
                flying = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
        if (chasing == true)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("fly");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("chasing");
            
            //Si el fantasma alcanza al jugador, se activa la muerte
            if (ai.remainingDistance <= catchDistance)
            {
                player.gameObject.SetActive(false);
                aiAnim.ResetTrigger("fly");
                aiAnim.ResetTrigger("idle");
                aiAnim.ResetTrigger("chasing");
                aiAnim.SetTrigger("jumpscare");
                StartCoroutine(deathRoutine());
                chasing = false;
            }
        }
        if (flying == true)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = flySpeed;
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("chasing");
            aiAnim.SetTrigger("fly");
            
            // El fantasma reposa en el punto de destino. 
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("chasing");
                aiAnim.ResetTrigger("fly");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                flying = false;
            }
        }                
    }
    IEnumerator stayIdle()
    {
        // Esperar un tiempo aleatorio en el destino actual y luego continuar hacia un nuevo destino.

        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        flying = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
    }
    IEnumerator chaseRoutine()
    {
        // Perseguir al jugador por un tiempo aleatorio y luego dejar de perseguirlo.

        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        flying = true;
        chasing = false;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
    }
    IEnumerator deathRoutine()
    {
        // Activar la animacion de muerte y cargar nuevamente la escena despues de morir.
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}