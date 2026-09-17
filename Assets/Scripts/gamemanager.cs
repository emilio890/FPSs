using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    public bool isplaying;
    [SerializeField]
    private float gametime = 10f;
    [SerializeField]
    private TMP_Text  Timescreen;
    [SerializeField]
    private TMP_Text  score;
    [SerializeField]
    private int points = 0;
    [SerializeField]
    private GameObject panelpause;

    [SerializeField]
    private InputAction Esc;

    private void OnEnable()
    {
        Esc.Enable();

    }
    private void OnDisable()
    {
        Esc.Disable();
    }
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
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       if (Esc.triggered)
        {
            pause();
        }
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
            SceneManager.LoadScene(3);
        }
        
    }
    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }
    public void AddTime(float time)
    {
        gametime += time;
    }
    public void addscore(int enemypoints)
    {
        points += enemypoints;
        score.text = "Score: " + points.ToString();
    }
    public void pause()
    {
        Time.timeScale = 0f;
        panelpause.SetActive(true);
    }
    public void Go()
    {
        Time.timeScale = 1f;
        panelpause.SetActive(false);
    }
    public void Menu ()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
