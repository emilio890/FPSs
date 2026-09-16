using System;
using UnityEngine;

public class gameevent : MonoBehaviour
{
    public static gameevent instance;
    public event Action ondoortriggerenter;
    public event Action ondoortriggeredexit;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void OpenTriggerDoor()
    {
        ondoortriggerenter();
    }
    public void CloseTriggerDoor()
    {
        ondoortriggeredexit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
