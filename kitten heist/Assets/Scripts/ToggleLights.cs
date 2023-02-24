using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLights : MonoBehaviour
{
    public bool lightsOn;
    public GameObject player;

    [Header("Night Vision")]
    public GameObject nightVision;

    // Start is called before the first frame update
    void Start()
    {
        lightsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lightsOn) {
            nightVision.SetActive(true);
        } else {
            nightVision.SetActive(false);
        }
        
    }

    private void OnMouseDown() {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (lightsOn && distance < 2) {
            lightsOn = false;
            
            print("Lights off");
        } else {
            lightsOn = true;
            print("Lights on");
        }    
    }
}
