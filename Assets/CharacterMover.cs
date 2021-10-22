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
    public float rotateValue = 3f;
    public float vel = 3f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    private LineRenderer laserLine;                                        // Reference to the LineRenderer component which will display our laserline
    private float nextFire;

    public int gunDamage = 1;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;                                        // Number in seconds which controls how often the player can fire
    public float weaponRange = 50f;                                        // Distance in Unity units over which the player can fire
    public float hitForce = 100f;

    public Transform gunEnd;

    bool isRotatingLeft = false;
    bool isRotatingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rigiddbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.Play("idle");
        audioSource = this.GetComponent<AudioSource>();
        laserLine = GetComponent<LineRenderer>();

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
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = rigiddbody.position;

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Check if our raycast has hit anything
            if (Physics.Raycast(transform.position, transform.forward, out hit, weaponRange))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                // Get a reference to a health script attached to the collider we hit
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                // If there was a health script attached
                if (health != null)
                {
                    Debug.Log(health);
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }

                // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, transform.position + (transform.forward * weaponRange));
            }
        }

        if (Input.anyKey == false)
        {
            anim.Play("idle");
        }
    }
    private IEnumerator ShotEffect()
    {

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}
