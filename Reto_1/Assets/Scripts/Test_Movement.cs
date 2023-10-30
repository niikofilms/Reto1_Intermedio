using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Test_Movement : MonoBehaviour
{
    // Variable Definition

    public Transform Player_Current_Position;
    public LayerMask LayerPlayer;
    public float EnemyRange_lenght;
    bool isEnemyActive;
    public GameObject[] Enemy_Path_Positions;
    Vector3 V3Enemy_target_pos;
    NavMeshAgent NavMesh_Agent;
    public float minIdleTime, maxIdleTime;
    public float ghost_velocity;
    Vector3 Ghost_Position;
    float Time, Distance;


    void Start()
    {
        //Initialize the Navmeshagent Corutines and Vector3

        NavMesh_Agent = GetComponent<NavMeshAgent>();
        V3Enemy_target_pos = NavMesh_Agent.destination;
        Ghost_Position = transform.position;
        StartCoroutine(Enemy_Walk_Path());


    }


    private void Update()
    {
        Distance = Vector3.Distance(V3Enemy_target_pos, Player_Current_Position.position);
        //Check if Player is on the same layer
        isEnemyActive = Physics.CheckSphere(transform.position, EnemyRange_lenght, LayerPlayer);

        if (isEnemyActive == true)
        {

            //Check the distance between Enemy and Player and start to follow

            if (Distance > 1.0f)
            {
                V3Enemy_target_pos = Player_Current_Position.position;
                NavMesh_Agent.destination = V3Enemy_target_pos;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Enemy_Walk_Path()
    {

        
        float Distance_Difference;

        while (true)
        {
            //Wait a random time


            
            for (int i = 0; i < Enemy_Path_Positions.Length; i++)
            {

                GameObject Path_Point = Enemy_Path_Positions[i];              
                Vector3 targetPosition = Path_Point.transform.position;
                NavMesh_Agent.destination = targetPosition;
                
                Distance_Difference = Vector3.Distance(Ghost_Position, targetPosition);
                Time = Distance_Difference / ghost_velocity;
                i = Random.Range(0, Enemy_Path_Positions.Length);
                yield return new WaitForSeconds(Time);
            }


            
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, EnemyRange_lenght);
    }
}
