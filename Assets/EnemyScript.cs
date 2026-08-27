using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float heal = 10;
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField]
    private GameObject knife;
    public List<Transform> patrullaje = new List<Transform>();
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = GameObject.Find("player").transform;
        agent.stoppingDistance = 3;
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 10)
        {
            agent.destination = player.position;
        }
        else
        {
            agent.destination = patrullaje[0].position;
        }
           

         if (Vector2.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }
    }
    public void TakeDamage(float value)
    {
        heal -= value;
        if (heal <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
