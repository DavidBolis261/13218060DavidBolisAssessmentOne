using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In This File there are methods which control the clock wise movement of PacMan, this is what should be marked this Assessment.
//This file also contains PacMan Movement which work based on user input, this should not be marked in this Assessment.

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 destination = Vector2.zero;
    public AudioSource audiosource;
    public AudioSource PacManEating;

    void Start()
    {
        right();
       
        destination = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.tag == "Pallet")
        // {
        //     PacManEating.Play();   
        // }
    }

    void right(){
        GetComponent<Animator>().SetFloat("DirX", 1);
    GetComponent<Animator>().SetFloat("DirY", 0);
    audiosource.Play();
    LeanTween.moveX(gameObject, 3.7f, 1).setOnComplete(down);
    
    }
    void down(){
            audiosource.Play();

        GetComponent<Animator>().SetFloat("DirX", 0);
        GetComponent<Animator>().SetFloat("DirY", -1);
        LeanTween.moveY(gameObject, 34.88f, 1).setOnComplete(left);
    }
    void left(){
            audiosource.Play();

        GetComponent<Animator>().SetFloat("DirX", -1);
        GetComponent<Animator>().SetFloat("DirY", 0);
        LeanTween.moveX(gameObject, -7.01f, 1).setOnComplete(up);
    }
    void up(){
            audiosource.Play();

        GetComponent<Animator>().SetFloat("DirX", 0);
        GetComponent<Animator>().SetFloat("DirY", 1);
        LeanTween.moveY(gameObject, 38.47f, 1).setOnComplete(right);
    }
  

    bool valid(Vector2 dir)
    {
       
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }


//This Function Should Not be marked.
private void InputMovement(){
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
    } 
}
