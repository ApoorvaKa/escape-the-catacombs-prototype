using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLights : MonoBehaviour
{
    public bool lightsOn;
    //public GameObject player;
    public LayerMask layer;
    [Header("Night Vision")]
    public GameObject nightVision;
    public GuardController fixer;
    // Start is called before the first frame update
    void Start()
    {
        lightsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector2.Distance(Player.p.transform.position, transform.position);
            if (distance < 2)
            {
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 0, layer);
                if (hit)
                {
                    Toggle();
                }
            }
        }

    }

    public void Toggle()
    {

        if (lightsOn)
        {
            lightsOn = false;
            nightVision.SetActive(true);
            fixer.GoToFixLight(transform, this);
            foreach(var e in FindObjectsByType<GuardController>(FindObjectsSortMode.None))
            {
                e.TurnOffLight();
            }
        }
        else
        {
            lightsOn = true;
            nightVision.SetActive(false);
            foreach (var e in FindObjectsByType<GuardController>(FindObjectsSortMode.None))
            {
                e.TurnOnLight();
            }
        }
    }

    //private void OnMouseDown() {
    //    float distance = Vector2.Distance(player.transform.position, transform.position);
    //    if (lightsOn && distance < 2) {
    //        lightsOn = false;
            
    //        print("Lights off");
    //    } else {
    //        lightsOn = true;
    //        print("Lights on");
    //    }    
    //}
}
