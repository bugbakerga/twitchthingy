using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeMovement : MonoBehaviour
{
    public bool ismoving;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float speed;

    public float walkPointRange;
    public GameObject thelight;
    public ParticleSystem particle;
    public Animator animator;

    public GameObject[] prizeobjects;
    private int randomtime;
    private int randomprize;

    void Start()
    {
        StartCoroutine(moveprize());
        randomprize = Random.Range(0, prizeobjects.Length);
        randomtime = Random.Range(5, 15);
    }

    private void Update()
    {
        if (ismoving == true)
        {
            Patroling();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        transform.LookAt(walkPoint);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

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
        walkPointSet = true;
    }

    IEnumerator moveprize()
    {
        yield return new WaitForSeconds(3f);
        ismoving = true;
        thelight.SetActive(true);
        particle.Play();
        animator.SetTrigger("patrol");
        yield return new WaitForSeconds(randomtime);
        animator.SetTrigger("despawn");
        yield return new WaitForSeconds(0.26f);
        Instantiate(prizeobjects[randomprize], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

}
