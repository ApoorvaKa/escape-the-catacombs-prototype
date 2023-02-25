using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour
{

    public GameObject player;
    public GameObject exitPosition;

    public bool isHiding;

    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
    }

    void Update(){
        // input e for interact
        if (Input.GetKeyDown(KeyCode.E)){
            HidePlayer();
        }

    }

    private void HidePlayer() {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance < 2) {
            if (isHiding){
                player.transform.position = exitPosition.transform.position;
                GetComponent <SpriteRenderer>().color = Color.white;
                isHiding = false;
                print("Player not hiding");
            }
            else{
                player.transform.position = transform.position;
                GetComponent <SpriteRenderer>().color = Color.green;
                isHiding = true;
                print("Player hiding");
            }
        }
    }
}
