using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoTrigger : MonoBehaviour
{
    public int EnemyDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CharController>().CurrentHealth -= EnemyDamage;
        }
    }
}
