using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;


public class Drone : MonoBehaviour
{
    public float wanderRadius = 7f;
    public Transform fpsc;
    public float fov = 120f;
    public float viewDistance = 10f;
    public float wanderSpeed;
    public float chaseSpeed;
    public bool isAware = false;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    private Renderer renderer;
    private float fpscNEW;



    void Start()
    {
        fpsc = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        wanderPoint = RandomWanderPoint();
    }


   public void Update()
    {

        // fpscNEW = fpsc.transform.position.y + this.transform.position.y;
        // fpscnew = (fpsc.transform.position.x, fpsc.transform.position.z, fpscNew);

        if (isAware)
        {
            AlertOthers();
            agent.SetDestination(fpsc.transform.position);
            renderer.material.color = Color.red;
            GetComponent<NavMeshAgent>().speed = chaseSpeed;
        }
        else
        {
            SearchForPlayer();
            Wander();
            renderer.material.color = Color.blue;
            GetComponent<NavMeshAgent>().speed = wanderSpeed;
        }

        if (Vector3.Distance(fpsc.transform.position, transform.position) > viewDistance)              
        {
            isAware = false;
        }
    }

    public void SearchForPlayer()
    {
        if(Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, fpsc.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                }
            }

        }
    }


    public void AlertOthers()
    {
        //Use SphereCast to collide with others near it
        //OnCollision set isAware = true
        //might have to temporarily raise view distance so they don't wander immediatley
        //orr..... if they still go to the players last known position then maybe leave it
        //isAware has AlertOthers() in it creating a chain reaction that tells people around it
    }

    public void OnAware()
    {
        isAware = true;
    }

    public void Wander()
    {
        if (Vector3.Distance(transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
}
