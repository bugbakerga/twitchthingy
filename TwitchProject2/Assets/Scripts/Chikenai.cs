using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chikenai : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator overheadtext;

    public LayerMask whatIsGround;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public bool isStarted = false;
    public bool isfighting = true;
    bool canboost = true;

    //particles
    public GameObject redptc;
    public GameObject whiteptc;

    //gfx objects
    public GameObject chickengfx;
    public Material[] chickencolors;
    public Animator chickenanims;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void beginmatch()
    {
        isStarted = true;
    }

    public void attackplayer()
    {
        chickenanims.SetTrigger("attack");
    }

    private void Update()
    {
        if (isStarted == true)
        {
            Patroling();
            chickenanims.SetBool("iswalking", true);
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

    public void Boost()
    {
        if(canboost == true)
        {
            canboost = false;
            agent.speed = 8.7f;
            chickenanims.speed = 2f;
            Instantiate(redptc, transform.position, Quaternion.identity);
            chickengfx.GetComponent<Renderer>().material = chickencolors[1];
        }
    }

    public void UnBoost()
    {
        if(canboost == false)
        {
            canboost = true;
            agent.speed = 3.5f;
            chickenanims.speed = 1f;
            Instantiate(whiteptc, transform.position, Quaternion.identity);
            chickengfx.GetComponent<Renderer>().material = chickencolors[0];
        }
    }

    public void takedamage()
    {
        return;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }
}
