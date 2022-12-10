using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooling : MonoBehaviour
{
    public static objectPooling instance;
    public List<GameObject> obstacles = new List<GameObject>();

    public Transform desPos;

    private GameObject notlistedObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        Shoot();
    }
    private void Shoot()
    {
        obstacles[0].gameObject.SetActive(true);
        obstacles[0].GetComponent<Rigidbody>().velocity = Vector3.forward * 10;
        notlistedObject = obstacles[0];
        obstacles.RemoveAt(0);
        Invoke("GetToThePool", 2);
    }
    public void GetToThePool()
    {
        obstacles.Add(notlistedObject);
        notlistedObject.transform.position = desPos.position;
        notlistedObject.SetActive(false);
        Shoot();
    }

}