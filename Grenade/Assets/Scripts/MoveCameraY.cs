using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraY : MonoBehaviour
{
    Vector3 cur;
    public float sens = 4.0f;
    void Update()
    {
            transform.Rotate(Input.GetAxis("Mouse Y") * sens * -1, 0, 0);
    }
}
