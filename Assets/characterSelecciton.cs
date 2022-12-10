using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelecciton : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;
    void Start()
    {
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
    }
    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
