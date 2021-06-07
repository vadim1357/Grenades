using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrenade : MonoBehaviour
{
    public GrenadeType type;
    
    void Update()
    {
        transform.Rotate(0, 80 * Time.deltaTime, 0);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            Inventory.Instance.AddGrenade(type);
            GameManager.countGrenOnScene[type]--;

            Destroy(gameObject);
        } 
    }
}
