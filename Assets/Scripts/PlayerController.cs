using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using System.Collections;


public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;
    private bool canJump = false;
    private Rigidbody2D rigid;
    private Animator anim;
    private bool faceRight = true;
    private float moveInput;
    public GameObject replay_button;
    public GameObject next_button;
    [SerializeField]
    private Button jumpButton;
    private bool platformTemas = false;
    [SerializeField]
    internal float KBforce;
    [SerializeField]
    internal float KBcounter;
    [SerializeField]
    internal float KBTotalTime;

    internal bool KnocbackFromRight;
    public AudioSource audio_jumping;
    public AudioSource audio_death;





    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        replay_button.SetActive(false);
        next_button.SetActive(false);
        Time.timeScale = 1;
    }
    private void FixedUpdate()
    {
        if (KBcounter <= 0)
        {
            rigid.velocity = new Vector2(moveInput * speed, rigid.velocity.y);
        }
        else
        {
            if (KnocbackFromRight == true)
            {
                rigid.velocity = new Vector2(-KBforce, KBforce);
            }
            if (KnocbackFromRight == false)
            {
                rigid.velocity = new Vector2(KBforce, KBforce);
            }
            KBcounter -= Time.deltaTime;
        }

        anim.SetBool("Running", moveInput != 0);

        if (faceRight && moveInput < 0)
        {
            Flip();
        }
        else if (!faceRight && moveInput > 0)
        {
            Flip();
        }
    }

    IEnumerator jumpbtnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (platformTemas == true)
        {
            jumpButton.interactable = true;
            canJump = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.transform.tag != "Platform") return;

        StartCoroutine(jumpbtnDelay(0.1f));
        platformTemas = true;
        canJump = true;
        anim.SetBool("Jumping", false);
        jumpSpeed = 450f;
    }
    private void OnCollisionExit2D(Collision2D temas)
    {

        jumpSpeed = 0f;
        canJump = false;
        jumpButton.interactable = false;
        platformTemas = false;
        anim.SetBool("Jumping", true);

    }

    public void moveRight()
    {
        moveInput = 1;
    }
    public void moveLeft()
    {
        moveInput = -1;
    }
    public void stopMovement()
    {
        moveInput = 0;
    }

    public void Jump()
    {
        if (!canJump) return;

        rigid.AddForce(Vector2.up * jumpSpeed);
        jumpButton.interactable = false;
        canJump = false;
        platformTemas = false;
        anim.SetBool("Jumping", true);
        audio_jumping.Play();
    }
    private void Flip()
    {
        faceRight = !faceRight;
        float h = moveInput;
        if (h > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        else if (h < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }



    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "fallcontrol")
        {
            audio_death.Play();
            Time.timeScale = 0;
            replay_button.SetActive(true);
        }
        else if (temas.gameObject.tag == "finish")
        {
            next_button.SetActive(true);
            Time.timeScale = 0;

        }
        else if (temas.gameObject.tag == "saw")
        {
            audio_death.Play();
            Time.timeScale = 0;
            replay_button.SetActive(true);
        }


    }
}