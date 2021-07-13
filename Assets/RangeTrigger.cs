using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour
{
    private EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = transform.root.GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyAI.InRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyAI.InRange = false;
        }
    }

}
