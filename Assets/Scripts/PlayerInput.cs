using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityAction onPressShoot;
    public float horizontal {get; private set;}
    public float vertical {get; private set;}
    public Vector3 pointAt {get; private set;}

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        pointAt = Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.up + Vector3.right);
        if (Input.GetButton("Fire1"))
            onPressShoot.Invoke();
    }
}
