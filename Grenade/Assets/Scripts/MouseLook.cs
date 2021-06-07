using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sens = 4.0f;
    
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sens, 0);
       
    }
}
