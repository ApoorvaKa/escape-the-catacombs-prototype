using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player p;

    public float speed;
    public bool canMove = true;
    public bool isHiding = false;

    private Rigidbody2D rb;
    float horizontal, vertical;

    void Start() {
        p = this;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        if (canMove && !isHiding) {
            GetComponent<BoxCollider2D>().enabled = true;
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horizontal, vertical).normalized * speed;

        } else {
            rb.velocity = new Vector2(0, 0);
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
