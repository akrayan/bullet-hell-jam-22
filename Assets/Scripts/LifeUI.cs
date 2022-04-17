using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slider lifeSlider;
    [SerializeField] private TextMeshProUGUI lifeNumber;
    
    
    void Start()
    {        
        playerHealth.onLifeChange += onLifeUpdate;
    }

    void onLifeUpdate(int currentLife, int maxLife) {
        lifeNumber.text = "" + currentLife + " / " + maxLife ;
        lifeSlider.value = (float)currentLife / (float)maxLife;
    }
}
