using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    public bool isplaying;
    [SerializeField]
    private float gametime = 10f;
    [SerializeField]
    private TMP_Text  Timescreen;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
       if  (gametime > 0)
        {
            gametime -= Time.deltaTime;
            int min = (int)gametime / 60;
            int seg = (int) gametime % 60;
            Timescreen.text = min.ToString("00") + ":" + seg.ToString("00");
            
        }
       if (gametime <= 0)
        {
            isplaying = false;
        }
        
    }
}
