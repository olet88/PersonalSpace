using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform player;
    public Transform self;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.5f;
        self.LookAt(player);

        self.position += self.forward * speed * Time.deltaTime;
        if (Vector3.Distance(self.position, this.transform.position) < 5)
        {
            Vector3 direction = self.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("IsIdle", false);
            if (direction.magnitude > .8)
            {
                speed = 1.0f;
                anim.SetInteger("legs", 2);
                anim.SetInteger("arms", 2);
            }
            else
            {
                speed = 0.5f;
                anim.SetInteger("legs", 1);
                anim.SetInteger("arms", 1);
            }


        }
        else
        {
            speed = 0;
            anim.SetInteger("legs", 4);
            anim.SetInteger("arms", 6);
        }
    }
}
