using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event System.Action BossPrepare; //Hazırlanma = UI
    public static event System.Action BossExhausted; //Boss Hasar Almaya Başlar
    public static event System.Action BossAttacking; //Movement
    public static event System.Action BossSawExhausted; // Exhausted + SawStart
    public static event System.Action angryBossAttacking; // Movement++;
    public static event System.Action BossFinish; // Finish
    [SerializeField] private Text victory;
    [SerializeField] private GameObject particlesystem;

    IEnumerator Boss1()
    {
        BossExhausted?.Invoke();

        yield return new WaitUntil(() => BossStats.health == 2);
        yield return new WaitForSeconds(0);
        BossAttacking?.Invoke();
    }
    IEnumerator Boss2()
    {
        BossPrepare?.Invoke();
        yield return new WaitForSeconds(5);
        BossSawExhausted?.Invoke();
        yield return new WaitForSeconds(20);
        BossExhausted?.Invoke();
        yield return new WaitUntil(() => BossStats.health == 1);
        yield return new WaitForSeconds(0);
        BossAttacking?.Invoke();
        yield return new WaitForSeconds(10);
        BossPrepare?.Invoke();
        yield return new WaitForSeconds(5);
        angryBossAttacking?.Invoke();
        yield return new WaitForSeconds(30);
        BossFinish?.Invoke();
        yield return new WaitUntil(() => BossStats.health == 0);
        VictoryText();
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Seviyeler2");


    }
    private void Start()
    {
        Boss.bExhausted = false;
        Boss.bSawExhausted = false;
        Boss.angrybAttack = false;
    }
    IEnumerator VictoryUI()
    {
        yield return new WaitUntil(() => BossStats.health == 0);
        victory.GetComponent<Text>().enabled = true;
        particlesystem.SetActive(true);
    }

    private void Update()
    {
        if (Boss.bExhausted == true)
        {
            StartCoroutine(Boss1());
            Boss.bExhausted = false;
        }
        if (Boss.bSawExhausted == true)
        {
            StartCoroutine(Boss2());
            Debug.Log("SawExhausted");
            Boss.bSawExhausted = false;
        }
        if (Boss.angrybAttack == true)
        {
            StartCoroutine(Boss2());
            Debug.Log("angryAttack");
        }
    }
    private void VictoryText() => StartCoroutine(VictoryUI());






}
