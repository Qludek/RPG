using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private float i;
    private GameObject thePlayer;
    private Animator anim;
    private float distance;
    public float pursueSpeed;
    public player_movement playerThingies;

    private void Awake()
    {
        playerThingies = FindObjectOfType<player_movement>();
    }

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (thePlayer != null)
        {
            distance = Vector2.Distance(transform.position, thePlayer.transform.position);
            if (distance <= 2.7f)
            {
                playerThingies.afterThrustDelay -= Time.deltaTime;
                if (playerThingies.afterThrustDelay <= 0)
                {
                    Vector2 pursuePlayer = new Vector2((transform.position.x - thePlayer.transform.position.x) * pursueSpeed, (transform.position.y - thePlayer.transform.position.y) * pursueSpeed);
                    anim.SetBool("IsMoving", true);
                    anim.SetFloat("MovingX", -pursuePlayer.x);
                    anim.SetFloat("MovingY", -pursuePlayer.y);
                    GetComponent<Rigidbody2D>().velocity = -pursuePlayer.normalized * pursueSpeed;
                }
            }
            else
            {
                if (moving)
                {
                    anim.SetBool("IsMoving", true);
                    timeToMoveCounter -= Time.deltaTime;
                    myRigidbody.velocity = moveDirection;
                    if (timeToMoveCounter < 0f)
                    {
                        moving = false;
                        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                    }
                }
                else
                {
                    anim.SetBool("IsMoving", false);
                    timeBetweenMoveCounter -= Time.deltaTime;
                    myRigidbody.velocity = Vector2.zero;
                    if (timeBetweenMoveCounter < 0f)
                    {
                        moving = true;
                        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                        i = Random.Range(-1f, 1f);
                        if (i < 0f)
                        {
                            moveDirection = new Vector2(Random.Range(-1f, 1f) * moveSpeed, 0f);
                            anim.SetFloat("MovingX", moveDirection.x);
                            anim.SetFloat("LastMoveX", moveDirection.x);
                            anim.SetFloat("LastMoveY", 0f);
                            anim.SetFloat("MovingY", 0f);
                        }
                        else
                        {
                            moveDirection = new Vector2(0f, Random.Range(-1f, 1f) * moveSpeed);
                            anim.SetFloat("MovingY", moveDirection.y);
                            anim.SetFloat("LastMoveY", moveDirection.y);
                            anim.SetFloat("LastMoveX", 0f);
                            anim.SetFloat("MovingX", 0f);
                        }

                    }
                }
            }
        }
    }
}