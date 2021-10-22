using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    Vector3 floatY;
    float originalY;

    public float floatStrength = 0.5f;

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        floatY = transform.position;
        floatY.y = originalY + (Mathf.Sin(Time.time) * floatStrength);
        transform.position = floatY;
    }
}
