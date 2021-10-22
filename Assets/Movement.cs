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

        self.rotation *= new Quaternion(0, 90, 0, 0);
        self.eulerAngles = new Vector3(0, self.eulerAngles.y, 0);
        // Vector3 direction = self.position - player.position;
        // direction = new Vector3(0, direction.y, 0);
        // self.rotation = Quaternion.Slerp(this.transform.rotation,
        //                             Quaternion.LookRotation(direction), 0.1f);

        self.position -= self.forward * speed * Time.deltaTime;
        if (Vector3.Distance(self.position, player.position) < 5)
        {


            anim.SetBool("IsIdle", false);
            if (Vector3.Distance(self.position, player.position) > 2)
            {
                speed = 5.0f;
                anim.SetInteger("legs", 2);
                anim.SetInteger("arms", 2);
            }
            else
            {
                speed = 0f;
                anim.SetInteger("legs", 4);
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
}
