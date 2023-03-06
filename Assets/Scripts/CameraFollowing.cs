using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Transform Player;

    [SerializeField]
    private float smoothX;
    [SerializeField]
    private float smoothY;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;
    

    private void Start()
    {

        Player = GameObject.Find("Player").transform;
        

    }


    private void LateUpdate()
    {
        float posX = Mathf.MoveTowards(transform.position.x, Player.position.x, smoothX);
        float posY = Mathf.MoveTowards(transform.position.y, Player.position.y, smoothY);
        transform.position = new Vector3(Mathf.Clamp(posX, minX, maxX), Mathf.Clamp(posY, minY, maxY), transform.position.z);

    }
}
