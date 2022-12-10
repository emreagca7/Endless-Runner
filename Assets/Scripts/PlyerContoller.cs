using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerContoller : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public GameManager gameManager;
    public GameObject gameOverPanel;
    public float gravityModifier = 1;
    public float jumpForce;
    public bool isOnground = true;
    public bool gameOver = false;
    private bool canDoubleJump;
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        GameObject.Find("Game Manager").GetComponent<gameManager>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!gameOver && isOnground)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnground = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnground = true;
            gameManager.UptadeScore(1);
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            gameManager.yourScore.text = gameManager.scoreText.text;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAnim.SetFloat("Speed_f", 0);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOverPanel.SetActive(true);
        }
    }
}
