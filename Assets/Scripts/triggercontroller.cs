using UnityEngine;

public class triggercontroller : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        gameevent.instance.OpenTriggerDoor();
        
    }
    private void OnTriggerExit(Collider other)
    {
      
        gameevent.instance.CloseTriggerDoor();
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
