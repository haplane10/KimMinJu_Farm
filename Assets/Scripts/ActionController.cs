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

    [SerializeField] SceneController controller;
    
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

        if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetTrigger("Duck");
            if (onFarm)
            {
                farming.SetDigTile(transform.position);
            }
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetTrigger("Stab");
            if (onFarm)
            {
                farming.SetSeedTile(transform.position);
            }
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

    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mousePosition, Camera.main.transform.forward.normalized, 200f);
            //Debug.DrawRay(mousePosition, Camera.main.transform.forward.normalized, Color.red, 200f);
            if (hit)
            {
                if (hit.collider.CompareTag("House"))
                {
                    SceneController.Instance.LoadScene(2);
                }

                if (hit.collider.CompareTag("Shop"))
                {
                    SceneController.Instance.LoadScene(1);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Farm"))
        {
            Debug.Log("농장에 진입했습니다.");
            onFarm = true;
        }

        if (collision.CompareTag("Door"))
        {
            SceneController.Instance.LoadScene(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.C) && collision.CompareTag("Grow"))
        {
            Destroy(collision.gameObject);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (collision.CompareTag("House"))
            {
                SceneController.Instance.LoadScene(2);
            }
            else if (collision.CompareTag("Shop"))
            {
                SceneController.Instance.LoadScene(1);
            }
            //MouseClick();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Farm"))
        {
            Debug.Log("농장에서 나왔습니다.");
            onFarm = false;
        }
    }
}