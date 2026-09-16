using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private  float health = 5;
    [SerializeField]
    private Slider healthslider;
    void Start()
    {
        healthslider.value = health / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthslider.value = health / 10;
        if (health <= 0)
        {
            gamemanager.instance.ReloadLevel();
        }
    }
}
