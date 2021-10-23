using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnProx : MonoBehaviour
{
    public float distance = 50f;
    Material normalMaterial;
    public Material proximityMaterial;
    private bool proximity = false;

    // Start is called before the first frame update
    void Start()
    {
        normalMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");

        bool isClose = false;

        foreach (GameObject enemy in objs)
        {
            isClose = isClose || Vector3.Distance(enemy.transform.position, transform.position) < distance;
        }

        if (isClose != proximity)
        {
            proximity = isClose;
            GetComponent<MeshRenderer>().material = proximity ? proximityMaterial : normalMaterial;
        }
    }
}
