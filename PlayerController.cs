using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator playerAnim;
    public ParticleSystem expoParticle;
    public ParticleSystem dartParticle;
    public AudioClip jumpAudio;
    public AudioClip crashAudio;
    private AudioSource playerAudio;

    public float gravityModi;
    public float jumpForce = 600;
    public bool isGrounded = true;
    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModi;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerAudio.PlayOneShot(jumpAudio, 1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isGrounded = false;
            dartParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded");
            dartParticle.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashAudio, 1.0f);
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            expoParticle.Play();
            Debug.Log("Game Over");
            dartParticle.Stop();
        }
    }
}
