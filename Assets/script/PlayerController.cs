using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   //spawnpoint location
    [SerializeField]
    private GameObject spawnPoint ;
    
    //lsoe message
    [SerializeField]
    private GameObject loseimage;
    
    private float speed = 10f;
    private Rigidbody2D rb;
    
    //bool used with collision to make (respawn & lose message) only happen after collision with "lose" game object 
    private bool losing; 
    Vector3 loseposition = new Vector3(0,0,0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
        //mouse click to (spawn,destroy lose message, reset losing bool to false again after being true with collision.  
        if (Input.GetMouseButtonDown(0) & (losing.Equals(true)))
        {
            this.gameObject.transform.SetPositionAndRotation(spawnPoint.transform.position, Quaternion.identity);
            losing = false;
            Destroy(GameObject.FindWithTag("loselose"));
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        string collideTag = collision.gameObject.tag;
        if (collideTag == "lose") // if Mr Bean hits enemies, they will be destroyed and number of killed enemies increased by 1.
        {
            losing = true;
            Instantiate(loseimage, loseposition, Quaternion.identity);
        }
    }

   
}









