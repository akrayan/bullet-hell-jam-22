using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortelTrap : MonoBehaviour
{
    [SerializeField] private int enterDamages = 20;
    [SerializeField] private int durationDamages = 1;
    [SerializeField] private float durationDamagesTime = 10f;

    private float durationDamagesChrono;
    private IDameagble damageable = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        damageable = other.GetComponent<IDameagble>();
        damageable?.TakeDamages(enterDamages);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        damageable = null;
    }

    private void Start()
    {
        durationDamagesChrono = Time.time; // 10.01
    }

    private void FixedUpdate()
    {
        //                            10.05            10.05        +     00.03  =  10.08
        if (damageable != null && Time.time > durationDamagesChrono + durationDamagesTime)
        {
            damageable.TakeDamages(durationDamages);
            durationDamagesChrono = Time.time;
        }
    }
}
