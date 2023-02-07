using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using TMPro;

public class missileController : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    
    [SerializeField] private SpriteRenderer rebderer;
    [SerializeField] private Collider2D collider2d;

    
    public GameObject patlama;

    

   

    private void FixedUpdate()
    {
        var direction = PlayerController.Instance.transform.position - transform.position;
        direction = direction.normalized;

        var rotateAmount = Vector3.Cross(direction, transform.up).z;

        rigidbody2D.velocity = transform.up * (moveSpeed * Time.deltaTime);
        rigidbody2D.angularVelocity = -rotateAmount * (rotateSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("missile"))
        {
            kill();
            Instantiate(patlama, this.gameObject.transform.position, this.gameObject.transform.rotation);
            
        }
        if (collision.CompareTag("Player"))
        {
            kill();
            Instantiate(patlama, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void kill()
    {
        rebderer.enabled= false;
        collider2d.enabled= false;
        moveSpeed= 0;
       
    }
    
}
