using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent (typeof (NavMeshAgent))]
public class Follow : MonoBehaviour
{
   public Transform target;
    Vector3 dest;
    NavMeshAgent agente;

    public LayerMask LayerPlayer;
    public float     rangoEnemigo;
    bool             enemigoActivo;


    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        dest = agente.destination;
    }

    // Update is called once per frame
    void Update()
    {
        enemigoActivo = Physics.CheckSphere(transform.position, rangoEnemigo, LayerPlayer);
        if(enemigoActivo == true)
        {
            if (Vector3.Distance(dest, target.position) > 1.0f) 
            {
                dest = target.position;
                agente.destination = dest;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoEnemigo);
    }
}
