using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chikenai : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject[] player;

    public LayerMask whatIsGround;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public bool isStarted = false;
    public bool isfighting = false;
    public int randomchase;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void beginmatch()
    {
        player = GameObject.FindGameObjectsWithTag("Chicken");
        isStarted = true;
    }

    public void retreat()
    {
        isfighting = false;
    }

    public void fight()
    {
        isfighting = true;
        randomchase = Random.Range(0, player.Length);
    }

    private void Update()
    {
        if (isStarted == true)
        {
            if (!isfighting) Patroling();
            if (isfighting) ChasePlayer(randomchase);
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 3f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calculate random point in range
        float ramdomZ = Random.Range(-walkPointRange, walkPointRange);
        float ramdomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + ramdomX, transform.position.y, transform.position.z + ramdomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

   
    private void ChasePlayer(int chickenid)
    {
        if (player[chickenid] != this.gameObject)
        {
            agent.SetDestination(player[chickenid].transform.position);
        } 
        else
        {
            randomchase = Random.Range(0, player.Length);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
