using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedHeight : MonoBehaviour
{
    public float height = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}
