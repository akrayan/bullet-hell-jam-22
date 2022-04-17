using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDameagble
{
    [SerializeField] private uint maxLife = 100;

    public int currentLife { get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        currentLife = (int)maxLife;

        Debug.Log("Start Life at " + currentLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamages(int damages) {
        currentLife -= damages;
        Debug.Log("Ouille ! Sapristi jai pris " + damages + " ! i have now " + currentLife + " pdv");
    }
}
