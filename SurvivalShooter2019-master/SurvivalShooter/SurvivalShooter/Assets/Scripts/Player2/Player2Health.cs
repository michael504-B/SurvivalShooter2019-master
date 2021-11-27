using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player2Health : MonoBehaviour
{
    //added
    [SerializeField]
    AudioClip heartBeat;

    public int starting2Health = 100;
    public int current2Health;
    public Slider health2Slider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //added
    AudioSource hrtBeat;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake()
    {
        anim = GetComponent<Animator>();

        //added
        hrtBeat = GetComponent<AudioSource>();

        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        current2Health = starting2Health;


    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;


    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        current2Health -= amount;

        health2Slider.value = current2Health;

        playerAudio.Play();


        if (current2Health <= 0 && !isDead)
        {
            Death();

        }

        //added
        if (current2Health <= 50)
        {
            playerAudio.clip = heartBeat;
        }


    }



    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
