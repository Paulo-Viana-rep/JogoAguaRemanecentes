using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator enemyAnimator;
    private GameObject player;
   
    public int MaxHealth = 100;
    public int CurrentHealth = 10;
    public float Speed = 6.0f;
    public float AttackDistance = 6.0f;
    public float Gravity = 6.0f;
    public bool InRange = false;

    Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        enemyController = GetComponent<CharacterController>();
        enemyAnimator = GetComponent<Animator>();
        player = FindObjectOfType<CharController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange == true)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, transform.position.z));
            float dist = Vector3.Distance(transform.position, 
                new Vector3(player.transform.position.x, transform.position.y, transform.position.z));

            if (AttackDistance < dist)
            {
                if(enemyAnimator.GetBool("Walk") == false)
                {
                    enemyAnimator.SetBool("Walk", true);
                }

                if(transform.position.x > player.transform.position.x)
                {
                    moveDirection = new Vector3(-1, 0, 0);
                } 
                else
                {
                    moveDirection = new Vector3(1, 0, 0);
                }

                if (enemyAnimator.GetBool("Attack") == true)
                {
                    enemyAnimator.SetBool("Attack", false);
                }


                moveDirection *= Speed;
            } 
            else
            {
                moveDirection = Vector3.zero;
                if (enemyAnimator.GetBool("Walk") == true)
                {
                    enemyAnimator.SetBool("Walk", false);
                }

                if (enemyAnimator.GetBool("Attack") == false)
                {
                    enemyAnimator.SetBool("Attack", true);
                }
            }          
        }
        else
        {
            moveDirection = Vector3.zero;
            if (enemyAnimator.GetBool("Walk") == true)
            {
                enemyAnimator.SetBool("Walk", false);
            }
        }

        moveDirection.y -= Gravity * Time.deltaTime;
        enemyController.Move(moveDirection * Time.deltaTime);
    }
}
