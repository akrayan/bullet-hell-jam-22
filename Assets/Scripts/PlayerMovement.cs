using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Seerialize field permet d'afficher des variable private dans l'editeur
    [SerializeField] private float Speed = 1;

    private Rigidbody2D rb;
    private float horizontal = 0;
    private float vertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        rb.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
    }
}
