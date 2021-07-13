using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private CharacterController charController;
    private Animator charAnimator;
    
    private Vector3 moveDirection = Vector3.zero;


    [Header ("Parametros de Vida")]
    public int MaxHealth = 100;
    public int CurrentHealth = 10;
    public bool isInvulnerable;

    [Header("Parametros de Movimentação")]
    public float Speed = 10.0f;
    public float inAirSpeed = 50.0f;
    public float inAirDrift = 20.0f;
    public float JumpSpeed = 10.0f;
    public float Gravity = 20.0f;
    public float DashSpeed = 20.0f;
    public float DashTime = 0.25f;

    [Header("Parametros Doble Jump")]
    private int nrOfAlowedDJumps = 1;
    private int dJumpCounter = 0;
    private int dubleJump = 2; //determina a quantidade de jump



    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        charController = GetComponent<CharacterController>();
        charAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CharMove();
        Jump();
        ChangeDirection();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }else
        {
            isInvulnerable = false;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            AttackMellee();
        }
        else
        {
            charAnimator.SetBool("AttackMellee", false);
        }       

        moveDirection.y -= Gravity * Time.deltaTime;
        charController.Move(moveDirection * Time.deltaTime);

    }

    public void CharMove ()
    {
        if (charController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection *= Speed;
            dJumpCounter = 0;


            if (moveDirection.x != 0)
            {
                charAnimator.SetBool("Run", true);
            }
            else
            {
                charAnimator.SetBool("Run", false);
            }

        }
        else
        {
            moveDirection += transform.TransformDirection(
                new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * inAirDrift, 0, 0)
                * Time.deltaTime * inAirSpeed);
        }
    }

    public void ChangeDirection ()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float xScale = Mathf.Abs(transform.localScale.x);
            transform.localScale = Input.GetAxis("Horizontal") < 0 ?
                new Vector3(-xScale, transform.localScale.y, transform.localScale.z) :
                new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }
    } 

    public void Jump ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (charController.isGrounded)
            {
                charAnimator.SetBool("Jump", true);
                charAnimator.SetBool("Run", false);
                moveDirection.y = JumpSpeed;
                //dJumpCounter = 0;
            }

            if (!charController.isGrounded && dJumpCounter < nrOfAlowedDJumps) { }
            {
                if (dJumpCounter < dubleJump)
                {
                    charAnimator.SetBool("Jump", true);
                    moveDirection.y = JumpSpeed;
                    dJumpCounter++;
                }
                else
                {
                    charAnimator.SetBool("Jump", false);
                }
            }
        }
        else
        {
            charAnimator.SetBool("Jump", false);
        }
        
    }
    
    IEnumerator Dash ()
    {
        float startime = Time.time;

        while (Time.time  < startime + DashTime)
        {
            charController.Move(new Vector3(moveDirection.x, 0, 0) * DashSpeed * Time.deltaTime);
            isInvulnerable = true;
        
            yield return null;
        }
       
    }

    public void AttackMellee ()
    {
        
        charAnimator.SetTrigger("AttackMellee");
    }

}
