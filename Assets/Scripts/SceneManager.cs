using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Text yourScore;
    
    public bool isGameActive;
    public PlyerContoller playerController;


    public int score;
    // Start is called before the first frame update
    
    public void StartGame()
    {
        playerController.isOnground = true;

    }
    public void UptadeScore()
    {
        score++;
        scoreText.text = "Score :" + score;        
    }
   
}
