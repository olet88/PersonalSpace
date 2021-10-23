using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    AudioSource audioSource;
    private Animator anim;
    Rigidbody rigiddbody;
    public float rotateValue=3f;
    public float vel = 3f;

    bool isRotatingLeft = false;
    bool isRotatingRight = false;

    public bool HasBeer=false;

    // Start is called before the first frame update
    void Start()
    {
        rigiddbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.Play("idle");
        audioSource = this.GetComponent<AudioSource>();
    }

    public void FuckUnity()
    {
        HasBeer = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            anim.Play("running");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigiddbody.position += -transform.forward * Time.deltaTime * movementSpeed;
            anim.Play("running");
        }
        

        else if (Input.GetKey(KeyCode.A))
        {
            rigiddbody.position += -transform.right * Time.deltaTime * movementSpeed / 3;
            anim.Play("walking left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rigiddbody.position += transform.right * Time.deltaTime * movementSpeed / 3;
            anim.Play("walking right");
        }

        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, (Time.deltaTime / 10) * clockwise, 0);
            anim.Play("walking left");
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, (Time.deltaTime / 10) * -clockwise, 0);
            anim.Play("walking left");
        }

        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.Play("pistol shooting with recoil");
            audioSource.Play();
        }

        if (Input.anyKey == false)
        {
            anim.Play("idle");
        }
    }
}
