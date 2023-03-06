using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text victory;
    private void Start()
    {
        dangerArea1.SetActive(false);
        dangerArea2.SetActive(false);
        victory.GetComponent<Text>().enabled = false;
    }
    [SerializeField] private GameObject dangerArea1;
    [SerializeField] private GameObject dangerArea2;

    private void OnEnable()
    {
        GameManager.BossPrepare += startWarning;
        GameManager.BossExhausted += stopWarning;
        GameManager.angryBossAttacking += stopWarning;
        //GameManager.BossFinish += VictoryText;

    }
    private void OnDisable()
    {
        GameManager.BossPrepare -= startWarning;
        GameManager.BossExhausted -= stopWarning;
        GameManager.angryBossAttacking -= stopWarning;
        //GameManager.BossFinish -= VictoryText;
    }
    IEnumerator Warning()
    {
        yield return new WaitForSeconds(0);
        dangerArea1.SetActive(true);
        dangerArea2.SetActive(true);
        Debug.Log("Warning Enabled");
    }
    IEnumerator sWarning()
    {
        yield return new WaitForSeconds(0);
        dangerArea1.SetActive(false);
        dangerArea2.SetActive(false);
        Debug.Log("Warning Disabled");
    }

    private void startWarning() => StartCoroutine(Warning());
    private void stopWarning() => StartCoroutine(sWarning());





}
