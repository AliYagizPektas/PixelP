using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawManager : MonoBehaviour
{
    [SerializeField] private GameObject Saw1, Saw2;

    private void Start()
    {
        deActive(); ;
    }
    private IEnumerator ColliderStarter()
    {
        yield return new WaitForSeconds(2);
        Saw1.GetComponent<CapsuleCollider2D>().enabled = true;
        Saw2.GetComponent<CapsuleCollider2D>().enabled = true;
    }
    private void Active()
    {
        //Sprite Renderer
        Saw1.GetComponent<SpriteRenderer>().enabled = true;
        Saw2.GetComponent<SpriteRenderer>().enabled = true;
        //Collider
        StartCoroutine(ColliderStarter());
        //Movement

    }
    private void deActive()
    {
        //Sprite Renderer
        Saw1.GetComponent<SpriteRenderer>().enabled = false;
        Saw2.GetComponent<SpriteRenderer>().enabled = false;
        //Collider
        Saw1.GetComponent<CapsuleCollider2D>().enabled = false;
        Saw2.GetComponent<CapsuleCollider2D>().enabled = false;
        //Movement 

    }
    private void angryActive()
    {
        //Sprite Renderer
        Saw1.GetComponent<SpriteRenderer>().enabled = true;
        Saw2.GetComponent<SpriteRenderer>().enabled = true;
        //Collider
        StartCoroutine(ColliderStarter());
        TrapSaw.duration = 3f;
        //Movement Code


    }
    private void OnEnable()
    {
        GameManager.BossSawExhausted += Active;
        GameManager.BossExhausted += deActive;
        GameManager.angryBossAttacking += angryActive;
        GameManager.BossFinish += deActive;
    }
    private void OnDisable()
    {
        GameManager.BossSawExhausted -= Active;
        GameManager.BossExhausted -= deActive;
        GameManager.angryBossAttacking -= angryActive;
        GameManager.BossFinish -= deActive;

    }


}
