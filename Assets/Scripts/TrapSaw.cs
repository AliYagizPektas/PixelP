using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSaw : MonoBehaviour
{
    [SerializeField] private float targetX;
    private float startX;
    internal static float duration = 10f;
    private void Start()
    {
        startX = transform.localPosition.x;
        Move();
    }


    private void ChangeDir()
    {
        startX = targetX;
        targetX = -targetX;
        Move();
    }
    private void Move()
    {
        StartCoroutine(GraduallyChange.To(() => startX, x => transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z), targetX, duration, true, ChangeDir));
    }
}
