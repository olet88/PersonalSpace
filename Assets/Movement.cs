using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform player;
    public Transform self;
    public Animator anim;
    private LineRenderer laserLine;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.5f;
        self.LookAt(player);

        self.rotation *= new Quaternion(0, 90, 0, 0);
        self.eulerAngles = new Vector3(0, self.eulerAngles.y, 0);
        // Vector3 direction = self.position - player.position;
        // direction = new Vector3(0, direction.y, 0);
        // self.rotation = Quaternion.Slerp(this.transform.rotation,
        //                             Quaternion.LookRotation(direction), 0.1f);

        self.position -= self.forward * speed * Time.deltaTime;
        if (Vector3.Distance(self.position, player.position) < 5)
        {
            StartCoroutine(ShotEffect());
            RaycastHit hit;
            anim.SetBool("IsIdle", false);
            if (Vector3.Distance(self.position, player.position) > 2)
            {
                speed = 5f;
                anim.SetInteger("legs", 2);
                anim.SetInteger("arms", 2);
            }
            else
            {

                // Set the start position for our visual effect for our laser to the position of gunEnd
                laserLine.SetPosition(0, self.position);
                if (Physics.Raycast(transform.position, player.position, out hit, 3.0f))
                {
                    laserLine.SetPosition(1, hit.point);
                    // Get a reference to a health script attached to the collider we hit
                    PlayerDamage health = hit.collider.GetComponent<PlayerDamage>();

                    // If there was a health script attached
                    if (health != null)
                    {
                        // Call the damage function of that script, passing in our gunDamage variable
                        health.Damage(1);
                    }

                    // Check if the object we hit has a rigidbody attached
                    if (hit.rigidbody != null)
                    {
                        // Add force to the rigidbody we hit, in the direction from which it was hit
                        hit.rigidbody.AddForce(-hit.normal * 20f);
                    }
                }
                speed = 0f;
                anim.SetInteger("legs", 6);
                anim.SetInteger("arms", 6);
            }
        }
        else
        {
            speed = 2.5f;
            anim.SetInteger("legs", 1);
            anim.SetInteger("arms", 1);
        }
    }
    private IEnumerator ShotEffect()
    {

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return 0.25f;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}
