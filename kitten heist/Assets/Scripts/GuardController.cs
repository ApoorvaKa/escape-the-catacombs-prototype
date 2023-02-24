using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    public enum GuardStates
    {
        Stopped,
        Patrolling,
        FollowingPlayer,
        GoingToPoint,
        SpinAndSearch
    }

    public GuardStates state = GuardStates.Stopped;

    public AIDestinationSetter destSetter;
    public AIPath path;
    public Transform[] patrolPoints;
    public int index = 0;
    public Transform target;

    public Transform[] rayPoints;
    public LineRenderer[] lines;
    public float dist = 4f;
    public LayerMask rayLayer;
    public bool debugLines;

    public float patrolSpeed = 2f, alertSpeed = 4f;

    public float AlertTimer = 5f;
    public float AlertTimeLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void CastRays()
    {
        RaycastHit2D hit;
        for (int i = 0; i < rayPoints.Length; i++)
        {
            if (debugLines)
                lines[i].SetPosition(0, rayPoints[i].position);
            hit = Physics2D.Raycast(rayPoints[i].position, rayPoints[i].up, dist, rayLayer);
            
            if (hit)
            {
                //Vector2 localHit = transform.InverseTransformPoint(hit.point);
                if (debugLines)
                    lines[i].SetPosition(1, hit.point);
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    target = hit.transform;
                    destSetter.target = target;
                    state = GuardStates.FollowingPlayer;
                    AlertTimeLeft = AlertTimer;
                }
            } else
            {
                if (debugLines)
                {
                    Vector2 end = rayPoints[i].position + rayPoints[i].up * dist;
                    lines[i].SetPosition(1, end);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GuardStates.Stopped:
                path.maxSpeed = 0f;
                destSetter.target = patrolPoints[index];
                state = GuardStates.Patrolling;
                break;
            case GuardStates.Patrolling:
                path.maxSpeed = patrolSpeed;
                if (Vector2.Distance(transform.position, patrolPoints[index].position) < .1f)
                {
                    index = (index + 1) % patrolPoints.Length;
                    state = GuardStates.Stopped;
                }
                CastRays();
                break;
            case GuardStates.FollowingPlayer:
                path.maxSpeed = alertSpeed;
                
                CastRays();
                AlertTimeLeft -= Time.deltaTime;
                if (AlertTimeLeft <= 0)
                {
                    target = null;
                    state = GuardStates.Stopped;
                }
                break;
            case GuardStates.GoingToPoint:

                break;
            case GuardStates.SpinAndSearch:
                
                break;
            default:
                break;
        }
    }


}
