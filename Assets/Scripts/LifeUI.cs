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
    
    // exemple Event
    //public UnityAction<float> onDamaged { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        lifeSlider.value = 0.5f;
        lifeNumber.text = "50 / 100";
        //search player, register mon callbak when health change
    }

    void onLifeUpdate(int currentLife, int maxLife) {
        lifeNumber.text = "" + currentLife + " / " + maxLife ;
    }

}
