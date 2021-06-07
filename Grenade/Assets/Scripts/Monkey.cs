using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public HealthBar healthBar;
    private int maxHP = 4;
    private int curHP = 4;
    
   public void DoDamage()
    {
        curHP--;
        healthBar.SetHP(curHP, maxHP);
        if (curHP == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boom")
        {
            DoDamage();
            
        }
    }
    private void OnDestroy()
    {
        GameManager.checkEnemy--;
    }
}
