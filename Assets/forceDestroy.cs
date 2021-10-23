using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ForceDestroy()
    {
        Debug.Log("fuck unity");
        this.transform.position -= new Vector3(0, 11111111f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
