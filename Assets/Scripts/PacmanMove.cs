using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 destination = Vector2.zero;

    
    public AudioSource audiosource;
    public AudioSource PacManEating;
    void Start()
    {
       
        destination = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pallet")
        {
           
            PacManEating.Play();   
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        } else
        {
            audiosource.Stop();
        }
      

        Vector2 p = Vector2.MoveTowards(transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        if ((Vector2)transform.position == destination)
        {
            if ((Vector2)transform.position == destination)
            {
                if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                {
                    destination = (Vector2)transform.position + Vector2.up;
                    
     
                }
                    
                if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                {
                    destination = (Vector2)transform.position + Vector2.right;
                   
                }
                    
                if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                {
                    destination = (Vector2)transform.position - Vector2.up;
                }
                   
                if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                {
                    destination = (Vector2)transform.position - Vector2.right;
                }
                   
            }

        }
        Vector2 dir = destination - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    bool valid(Vector2 dir)
    {
       
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
