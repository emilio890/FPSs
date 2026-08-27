using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playershoiot : MonoBehaviour
{
    public Color hitColor;
    private int bullet;
    private int maxbullet;
    [SerializeField]
    private InputAction reloadkey;
    [SerializeField]
    private TMP_Text bulletText;
    [SerializeField]
    private ParticleSystem shootParticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        reloadkey.Enable();
    }
    private void OnDisable()
    {
        reloadkey.Disable();
    }
    void Start()
    {
        bullet = 10;
        maxbullet = 25;
        UpdateBulletText();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadkey.triggered)
        {
            if (maxbullet > 0)
            {
                if (maxbullet < 10)
                {
                    bullet += maxbullet;
                    maxbullet = 0;
                   
                }
                else
                {
                    bullet += 10;
                    maxbullet -= 10;
                }
                UpdateBulletText();
            }
           
        }
        if (Mouse.current.leftButton.wasPressedThisFrame && bullet > 0)
        {
            RaycastHit hit;
            bullet--;
            UpdateBulletText();
          
             shootParticles.Play();
            
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, hitColor);
                //Debug.Break(); Para pausar el juego
            }
        }
    }
    void UpdateBulletText()
    {
        bulletText.text = bullet.ToString() + " / " + maxbullet.ToString();
    }
    private void FixedUpdate()
    {
     
    }

    public void AddBullets(int value)
    {
        maxbullet += value;
        UpdateBulletText();
    }
}
