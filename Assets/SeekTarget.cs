using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : MonoBehaviour
{

    public Rigidbody rb;
    public Transform target;
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {

        Vector3 fixedTarget = new Vector3(target.position.x, 0, target.position.z);
        Vector3 fixedPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 fixedForward = Vector3.Normalize(new Vector3(transform.forward.x, 0, transform.forward.z));

        Vector3 targetDirection = fixedTarget - fixedPos;
        // rb.AddForce(10 * Time.deltaTime, 0, 0);
        // rb.AddTorque(0, 0.1f, 0);


        if (Vector3.Distance(target.position, transform.position) > 2)
        {
            rb.AddRelativeForce(0, 0, 1000 * Time.deltaTime);
        }

        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(fixedForward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}

