using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private SpriteRenderer rebderer;
    [SerializeField] private Collider2D collider2d;
    [SerializeField] public TMP_Text ScoreText;
    [SerializeField] public TMP_Text HighScoreText;

    public GameObject patlama;
    public GameObject gameover;
    public GameObject TryAgain;
    public GameObject Exit;
    public GameObject highscoree;
    public GameObject highscoreee;

    public int score;


    private float _input;

    void Start()
    {
         score= 0;
        

    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _input = Input.GetAxis("Horizontal");
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        HighScoreText.text = PlayerPrefs.GetInt("highScore").ToString();

    }


    private void FixedUpdate()
    {
        rigidbody2D.velocity= transform.up* (moveSpeed* Time.deltaTime);
        rigidbody2D.angularVelocity = -_input * (rotateSpeed * Time.deltaTime);
        if (moveSpeed>0)
        {
            score++;
        }
        

        ScoreText.text = score.ToString();

        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("missile")){
            kill();
            Instantiate(patlama, this.gameObject.transform.position, this.gameObject.transform.rotation);
            gameover.SetActive(true);
            TryAgain.SetActive(true);
            Exit.SetActive(true);
            highscoree.SetActive(true);
            highscoreee.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("alan"))
        {
            kill();
            Instantiate(patlama, this.gameObject.transform.position, this.gameObject.transform.rotation);
            gameover.SetActive(true);
            TryAgain.SetActive(true);
            Exit.SetActive(true);
            highscoree.SetActive(true);
            highscoreee.SetActive(true);
        }
    }

    private void kill()
    {
        rebderer.enabled = false;
        collider2d.enabled = false;
        moveSpeed = 0;

    }



}
