using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieBehavior : MonoBehaviour
{
    public Transform player;
    public List<Transform> locations;

    public int LocationIndex = 0;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in locations)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count > 0)
        {
            return;
        }
        agent.destination = locations[LocationIndex].position;
        LocationIndex = (LocationIndex + 1) % locations.Count;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            agent.destination = player.position;
            Debug.Log("Attack");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Resume Patrol");
        }
    }
}
