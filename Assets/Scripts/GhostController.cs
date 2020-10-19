using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //public Renderer rend;
    public GameObject[] DeadGhosts;
    public GameObject[] AliveGhosts;
    
    // Start is called before the first frame update
    void Start()
    {
        DeadGhosts = GameObject.FindGameObjectsWithTag("DeadGhost");
        AliveGhosts = GameObject.FindGameObjectsWithTag("AliveGhost");
        //StartCoroutine(ActivationRoutine());

        
    }

    private void GhostPMatch()
    {
        
    }

    private IEnumerator ActivationRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            foreach (GameObject ghost in AliveGhosts)
            {
                ghost.GetComponent<SpriteRenderer>().enabled = false;

            }

            yield return new WaitForSeconds(3);
            foreach (GameObject ghost in DeadGhosts)
            {
                ghost.GetComponent<SpriteRenderer>().enabled = false;

            }



            yield return new WaitForSeconds(3);
            foreach (GameObject ghost in AliveGhosts)
            {
                ghost.GetComponent<SpriteRenderer>().enabled = true;

            }

            yield return new WaitForSeconds(3);
            foreach (GameObject ghost in DeadGhosts)
            {
                ghost.GetComponent<SpriteRenderer>().enabled = true;

            }
        }
        
       
    }

}
