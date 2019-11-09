using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    GameObject player;
    private float currentOzoneVal;  
    private int currentHP;

    public Slider HPSlider;
    public Slider OzoneSlider;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(currentHP, 0, 100);
        HPSlider.value = currentHP;
        Mathf.Clamp(currentOzoneVal, 0, 100);
        OzoneSlider.value = currentOzoneVal;
    }
}
