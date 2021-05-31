using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    Animator animator;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float speed;
    [SerializeField] Farming farming;
    bool onFarm = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            animator.SetBool("Walk", true);
            
            if (x != 0)
            {
                transform.localScale = new Vector3(-x, 1, 1);
            }

            rigidbody.velocity += (new Vector2(x, y) * Time.deltaTime * speed);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (onFarm && Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetTrigger("Duck");
            farming.SetDigTile(transform.position);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetTrigger("Stab");
            farming.SetSeedTile(transform.position);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetTrigger("Swing");
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            animator.SetTrigger("Push");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Farm"))
        {
            Debug.Log("OnFarm");
            onFarm = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.C) && collision.CompareTag("Grow"))
        {
            Destroy(collision.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Farm"))
        {
            Debug.Log("Not OnFarm");
            onFarm = false;
        }
    }
}