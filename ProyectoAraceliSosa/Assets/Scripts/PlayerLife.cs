using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject[] hearts;
    private int life;
    private Animator anim;
    private Vector3 initialPosition;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        life = hearts.Length;
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        life--;
        

        if (life >= 1)
        {
            transform.position = initialPosition;

        }
        else
        {
            SceneManager.LoadScene("Over");
        }
    }

    private void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }
}
