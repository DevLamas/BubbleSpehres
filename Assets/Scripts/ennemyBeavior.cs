using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemyBeavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public Transform player;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private int _lives = 2;
    public int EnnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Ennemi KO");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatroleRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatroleRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
        {
            return;
        }
        _agent.destination = locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % locations.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
}
