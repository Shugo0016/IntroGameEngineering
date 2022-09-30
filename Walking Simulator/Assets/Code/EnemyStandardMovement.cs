using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

<<<<<<< Updated upstream
        
=======

>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if(!isWandering)
        {
            StartCoroutine(Wander());
        }
=======
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (isWalking)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
>>>>>>> Stashed changes
        if (isRotatingRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
<<<<<<< Updated upstream
        if (isWalking)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
=======
        
>>>>>>> Stashed changes
    }

    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;

        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotateWait);
        if (rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        isWandering = false;

    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
