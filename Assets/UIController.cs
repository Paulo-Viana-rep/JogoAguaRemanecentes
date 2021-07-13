using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    float playerHealth;
    
    public CharController Player;
    public Text TextLife;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = Player.CurrentHealth;
        TextLife.text = string.Format("Vida: {0}", playerHealth);
    }
}
