using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public GameObject life1, life2, life3, over;
    public static int health;

    public float speed;

    public Text countText;

    public Text winText;

    private Rigidbody2D rb2d;

    private int count;

    void Start()
    {


        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        winText.text = "";
        SetCountText();

    }
    
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);

        


        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("RedPickUp"))
        {
            other.gameObject.SetActive(false);
            GameControlScript.health = GameControlScript.health - 1;
            
        }
        if (count == 11) 
            {
            transform.position = new Vector2(50.0f, 0.0f); 
            }
       

        

    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win";
            GameControlScript.health = 3;
        }
    }
}
