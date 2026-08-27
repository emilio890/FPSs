using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private  float health = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gamemanager.instance.ReloadLevel();
        }
    }
}
