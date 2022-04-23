using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Seerialize field permet d'afficher des variable private dans l'editeur
    [SerializeField] private float Speed = 1;

    private Rigidbody2D rb;
    private PlayerInput pi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pi = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(pi.horizontal, pi.vertical, 0);
        rb.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
    }
}
