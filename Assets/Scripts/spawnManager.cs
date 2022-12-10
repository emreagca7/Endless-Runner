using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    private Vector3 spawnPos;
    [SerializeField] GameObject obstaclesPreFab;
    [SerializeField] float startTime;
    [SerializeField] float delayTime;
    [SerializeField] float spawnRate = 20;
    [SerializeField] float spawnPosStart;
    public PlyerContoller playarControllerScripts;
    public int score;
    void Awake()
    {
        playarControllerScripts = GameObject.Find("Player").GetComponent<PlyerContoller>();
        InvokeRepeating("startGame", startTime, delayTime);
    }
    public void startGame()
    {
        StartCoroutine(Spawner());
    }
    public void rateController()
    {
        if (PlayerPrefs.GetInt(nameof(score)) % 10 == 0)
        {
            if (PlayerPrefs.GetInt(nameof(score)) >= 3)
            {
                spawnRate -= 0.01f;
            }
        }
    }
    IEnumerator Spawner()
    {
        while (!playarControllerScripts.gameOver)
        {
            spawnPos = new Vector3(spawnPosStart, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(obstaclesPreFab, spawnPos, obstaclesPreFab.transform.rotation);
        }
    }
    void Update()
    {
        rateController();
        Spawner();
    }

}
