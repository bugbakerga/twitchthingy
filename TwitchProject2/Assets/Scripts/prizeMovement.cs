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

}
