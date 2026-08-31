using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using DG.Tweening;
public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float heal = 10;
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField]
    private GameObject knife;
    public List<Transform> patrullaje = new List<Transform>();
    
    private int currentPoint = 0;
    

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
            if(Vector3.Distance(transform.position, patrullaje[currentPoint].position)>= 3)
            {
                agent.destination = patrullaje[currentPoint].position;
            }
            else
            {
                if (currentPoint < patrullaje.Count-1)
                {
                    currentPoint++;
                }
                else
                {
                    currentPoint = 0;
                }
            }
                
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
        GetComponent<MeshRenderer>().material.DOColor(Color.red, 1).From();
        GetComponent<MeshRenderer>().material.DOColor(Color.gray, 1);
        if (heal <=0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
