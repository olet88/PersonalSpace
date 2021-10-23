using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickUp : MonoBehaviour
{
    [SerializeField]
    private GameObject barrel;
    public UnityEvent OnFoundBeer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("123");
        OnFoundBeer.Invoke();
        Debug.Log("fuck unity");
        if (collision.gameObject.tag == "player")
        {
        };
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player") {
            Debug.Log("fuck unity");
        };
    }

    // Update is called once per frame
    void Update()
    {
    }
}
