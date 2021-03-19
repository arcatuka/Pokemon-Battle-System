using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageBrust;
    public Transform Hitpoint;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(damageBrust, Hitpoint.position, Hitpoint.rotation);
        }
    }
}
