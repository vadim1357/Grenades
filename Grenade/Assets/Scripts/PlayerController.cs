using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform shootSpawn;
    public Transform trajectory;
    public GameObject greenGrenade;
    public GameObject yellowGrenade;
    public GameObject redGrenade;
    public GrenadeType activeGren;
    public GameObject boom;
    private bool checkRedGren;
    private bool checkGreenGren;
    private bool checkYellowGren;
    public Image curGren;
    public Text pointRed;
    public Text pointGreen;
    public Text pointYellow;



    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            checkRedGren = true;
            checkGreenGren = false;
            checkYellowGren = false;
            activeGren = GrenadeType.red;
           
            CurGren(pointRed.transform.localPosition, curGren);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            checkRedGren = false;
            checkGreenGren = true;
            checkYellowGren = false;
            activeGren = GrenadeType.green;
            
            CurGren(pointGreen.transform.localPosition, curGren);
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            checkRedGren = false;
            checkGreenGren = false;
            checkYellowGren = true;
            activeGren = GrenadeType.yellow;
            
            CurGren(pointYellow.transform.localPosition, curGren);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cast();
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position - transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + transform.right * speed*-1);
        }
    }
    
    IEnumerator Boom(GameObject pref)
    {
        GameObject newGren = Instantiate(pref);
        newGren.transform.position = shootSpawn.position;
        Rigidbody rb = newGren.GetComponent<Rigidbody>();
        Vector3 direction = trajectory.position - shootSpawn.position;
        rb.velocity = direction *                                   2;

        yield return new WaitForSeconds(3);

        Vector3 pos = newGren.transform.position;
        GameObject newboom = Instantiate(boom);
        newboom.transform.position = pos;
        Destroy(newGren.gameObject);
    }
    public void Cast()
    {
        if (checkRedGren)
        {
            if (Inventory.Instance.CheckGren(activeGren))
            {
                StartCoroutine(Boom(redGrenade));
                Inventory.Instance.UseGrenade(activeGren);
            }
            else
            {
                Debug.Log("notGrenRed");
            }
        }
        if (checkGreenGren)
        {
            if (Inventory.Instance.CheckGren(activeGren))
            {
                StartCoroutine(Boom(greenGrenade));
                Inventory.Instance.UseGrenade(activeGren);
            }
            else
            {
                Debug.Log("notGrenGreen");
            }
        }
        if (checkYellowGren)
        {
            if (Inventory.Instance.CheckGren(activeGren))
            {
                StartCoroutine(Boom(yellowGrenade));
                Inventory.Instance.UseGrenade(activeGren);
            }
            else
            {
                Debug.Log("notGrenYellow");
            }
        }
    } 
    public void CurGren(Vector3 pos,Image curGren)
    {
        
        curGren.transform.localPosition = pos;
    }
}
