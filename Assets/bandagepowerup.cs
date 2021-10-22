    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
     
    public class bandagepowerup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) // to see when the player enters the collider
        {
            if(other.gameObject.tag == "Player") //on the object you want to pick up set the tag to be anything, in this case "object"
            {
                other.GetComponent<Inventory>().AddBandageToInventory();
                Destroy(gameObject);
            }
        }
    }
     
