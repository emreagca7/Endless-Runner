using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneController : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
