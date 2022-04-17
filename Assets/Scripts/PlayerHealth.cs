using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDameagble
{
    [SerializeField][Min(0)] private int maxLife = 100;

    public int currentLife;

    public UnityAction<int, int> onLifeChange;

    void Start()
    {
        currentLife = maxLife;
        onLifeChange.Invoke(currentLife, maxLife);
    }

    public void TakeDamages(int damages) {
        currentLife -= damages;
        onLifeChange.Invoke(currentLife, maxLife);
    }
}
