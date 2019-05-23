using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {

    public float moveSpeed;
    private float CurrentMoveSpeed;
    public float DiagonalMoveMultiplier;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool playerMoving;

    public Vector2 lastMove;

    private bool IsAttacking;
    public float AttackTime;
    private float AttackTimeCounter;

    public static bool PlayerExist;

    public string StartPoint;

    public float thrust;
    public float afterThrustDelay;

    public SkillManager skillMan;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (!PlayerExist)
        {
            PlayerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
	}

    private void Awake()
    {
        skillMan = FindObjectOfType<SkillManager>();
    }

    // Update is called once per frame
    void Update () {
        playerMoving = false;
        if ((!IsAttacking) || (skillMan.moveAndAttack))
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(new Vector3 (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * CurrentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * CurrentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }
            if (Input.GetMouseButtonDown(0))
            {
                anim.speed = skillMan.attSpeed/10;
                AttackTimeCounter = AttackTime;
                IsAttacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }
            if(Mathf.Abs (Input.GetAxisRaw("Horizontal"))>0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                CurrentMoveSpeed = moveSpeed * DiagonalMoveMultiplier;
            }
            else
            {
                CurrentMoveSpeed = moveSpeed;
            }
            if (skillMan.bladeParade == true)
            {
                if (Input.GetKeyDown("j"))
                {
                    anim.Play("Skill_blade_dance");
                }
            }
        }
        if (AttackTimeCounter > 0)
        {
            AttackTimeCounter -= Time.deltaTime;
        }
        if (AttackTimeCounter <= 0)
        {
            IsAttacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            myRigidbody.AddForce(-(transform.position + other.transform.position).normalized * thrust/2);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position + other.transform.position).normalized * (thrust/5));
            afterThrustDelay = 1.5f;
        }
    }
}

