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

    //particles
    public GameObject redptc;
    public GameObject whiteptc;

    //gfx objects
    public GameObject chickengfx;
    public Material[] chickencolors;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void beginmatch()
    {
        isStarted = true;
    }

    public void fight()
    {
        if(isfighting == true)
        {
            isfighting = false;
            Boost();
            overheadtext.SetBool("isrecharged", false);
            Instantiate(redptc, transform.position, Quaternion.identity);
            chickengfx.GetComponent<Renderer>().material = chickencolors[1];
        }
    }

    private void Update()
    {
        if (isStarted == true)
        {
            Patroling();
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

    private void Boost()
    {
        agent.speed = 8.7f;
        StartCoroutine(speedup());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }

    IEnumerator speedup()
    {
        yield return new WaitForSeconds(3f);
        agent.speed = 3.5f;
        Instantiate(whiteptc, transform.position, Quaternion.identity);
        chickengfx.GetComponent<Renderer>().material = chickencolors[0];
        yield return new WaitForSeconds(10f);
        isfighting = true;
        overheadtext.SetBool("isrecharged", true);
    }
}
