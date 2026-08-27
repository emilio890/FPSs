using UnityEngine;

public class lootscript : MonoBehaviour
{
    [SerializeField]
    private int amountAmmo = 15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 45, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetChild(0).GetComponent<playershoiot>().AddBullets(amountAmmo);
            Destroy(this.gameObject);
        }
    }
}
