using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    public static PlyerContoller playerControllerScripts;
    [SerializeField] float leftBound = 10f;
    void Awake()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlyerContoller>();
    }
    void FixedUpdate()
    {
        if (!playerControllerScripts.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < -leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
