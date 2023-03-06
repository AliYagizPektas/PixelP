using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Boss : BossStats
{
    [SerializeField] private GameObject replay_button;
    public Transform firstPos, secondPos, thirdPos, fourthPos;
    internal static float mSpeed;
    internal static Vector3 nextPos;
    private Animator anim;
    private bool HitBoxCheck = false;
    [SerializeField] private GameObject boss;
    internal static bool thirdPosTrue = false;
    internal static bool fourthPosTrue = false;
    private bool faceRight;
    [SerializeField] private PlayerController playerController;
    private Rigidbody2D rb2d;
    internal static bool bExhausted = false;
    internal static bool bAttack = false;
    internal static bool angrybAttack = false;
    internal static bool bSawExhausted = false;
    public AudioSource audio_Playerdeath;
    public AudioSource audio_punch;
    private void Start()
    {
        // Buraya Bişey Yazma
        nextPos = firstPos.position;
        // .........................
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        HitBoxCheck = false;
        mSpeed = 4;
        // Boss Event
        bExhausted = false;
        bSawExhausted = false;
        angrybAttack = false;
        bAttack = false;
        // Boss Event

        // position
        thirdPosTrue = false;
        fourthPosTrue = false;
        //position
        BossStats.health = 3;

    }

    private void Update()
    {

        if (transform.position == secondPos.position && thirdPosTrue == false)
        {
            nextPos = thirdPos.position;
        }

        if (transform.position == secondPos.position)
        {
            FlipLeft();
        }
        if (transform.position == firstPos.position)
        {
            nextPos = secondPos.position;
            FlipRight();
        }

        if (transform.position == secondPos.position && thirdPosTrue == true)
        {
            nextPos = fourthPos.position;
        }
        if (transform.position == secondPos.position && fourthPosTrue == true)
        {
            nextPos = firstPos.position;

        }
        if (transform.position == thirdPos.position && thirdPosTrue == false)
        {
            nextPos = secondPos.position;
            bExhausted = true;
            FlipRight();
        }
        if (transform.position == fourthPos.position && fourthPosTrue == false)
        {
            fourthPosTrue = true;
            bSawExhausted = true;
            mSpeed = 0f;
            nextPos = firstPos.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, mSpeed * Time.deltaTime);

    }

    IEnumerator _isExhausted()
    {
        yield return new WaitForSeconds(0);
        Debug.Log("Exhausted");
        mSpeed = 0f;
        anim.SetBool("isAngry", false);
        anim.SetBool("isExhausted", true);
        HitBoxCheck = true;
    }
    IEnumerator _isAttack()
    {
        yield return new WaitForSeconds(3);
        mSpeed = 4f;
        HitBoxCheck = false;
        thirdPosTrue = true;
        anim.SetBool("isExhausted", false);
        anim.SetBool("isAngry", false);
        Debug.Log("isAttack");

    }
    IEnumerator _isSawAttack()
    {
        yield return new WaitForSeconds(0);
        mSpeed = 0f;
        anim.SetBool("isAngry", true);
        thirdPosTrue = false;
    }
    IEnumerator _isAngryAttack()
    {
        yield return new WaitForSeconds(0);
        mSpeed = 6f;
        anim.SetBool("isAngry", true);

    }
    IEnumerator _Finish()
    {
        yield return new WaitForSeconds(0);
        anim.SetBool("isAngry", false);
        anim.SetBool("isExhausted", true);
        HitBoxCheck = true;
        mSpeed = 0f;
        yield return new WaitUntil(() => health == 0);
        yield return new WaitForSeconds(1f);
        boss.SetActive(false);
        // resetBoss();
    }
    private void resetBoss()
    {
        bAttack = false;
        angrybAttack = false;
        Start();
    }
    private void isExhausted() => StartCoroutine(_isExhausted());
    private void isAttack() => StartCoroutine(_isAttack());
    private void isSawAttack() => StartCoroutine(_isSawAttack());
    private void isAngryAttack() => StartCoroutine(_isAngryAttack());
    private void Finish() => StartCoroutine(_Finish());

    private void OnEnable()
    {
        GameManager.BossExhausted += isExhausted;
        GameManager.BossAttacking += isAttack;
        GameManager.BossSawExhausted += isSawAttack;
        GameManager.angryBossAttacking += isAngryAttack;
        GameManager.BossFinish += Finish;
    }
    private void OnDisable()
    {
        GameManager.BossExhausted -= isExhausted;
        GameManager.BossAttacking -= isAttack;
        GameManager.BossSawExhausted -= isSawAttack;
        GameManager.angryBossAttacking -= isAngryAttack;
        GameManager.BossFinish -= Finish;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {

        if (temas.transform.tag == "Player" && HitBoxCheck == false)
        {
            audio_Playerdeath.Play();
            Time.timeScale = 0;
            replay_button.SetActive(true);
        }

        if (temas.gameObject.tag == "Player" && HitBoxCheck == true)
        {
            if (health == 1)
            {
                playerController.KBcounter = playerController.KBTotalTime;
                if (gameObject.transform.position.x <= transform.position.x)
                {
                    playerController.KnocbackFromRight = true;
                }
                if (gameObject.transform.position.x > transform.position.x)
                {
                    playerController.KnocbackFromRight = false;
                }
                Damage(1);
                audio_punch.Play();

            }
            if (health == 2)
            {
                playerController.KBcounter = playerController.KBTotalTime;
                if (gameObject.transform.position.x <= transform.position.x)
                {
                    playerController.KnocbackFromRight = true;
                }
                if (gameObject.transform.position.x > transform.position.x)
                {
                    playerController.KnocbackFromRight = false;
                }
                Damage(1);
                audio_punch.Play();
                HitBoxCheck = false;

            }

            if (health == 3)
            {
                playerController.KBcounter = playerController.KBTotalTime;
                if (gameObject.transform.position.x <= transform.position.x)
                {
                    playerController.KnocbackFromRight = true;
                }
                if (gameObject.transform.position.x > transform.position.x)
                {
                    playerController.KnocbackFromRight = false;
                }
                Damage(1);
                audio_punch.Play();
                HitBoxCheck = false;
            }



        }


    }
    private void FlipRight()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x = -2.5f;
        transform.localScale = scaler;

    }
    private void FlipLeft()
    {
        Vector3 scaler = transform.localScale;
        scaler.x = 2.5f;
        transform.localScale = scaler;

    }


}
