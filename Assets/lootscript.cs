using UnityEngine;

public class lootscript : MonoBehaviour
{
    public enum pickupselection
        {
        Life, ammo, time
        }

    public pickupselection currentselection;

    [SerializeField]
    private int amountAmmo = 15;

    private int amountLife = 10;
    private int amountTime = 25;
    void Start()
    {
        int value = Random.Range(0, 10);
        if (value > 7.5f)
        {
            currentselection = pickupselection.time;
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (value > 5)
        {
            currentselection = pickupselection.Life;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            currentselection = pickupselection.ammo;
            GetComponent<MeshRenderer>().material.color = Color.pink;
        }
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
            switch (currentselection)
            {
                case pickupselection.Life:
                    other.GetComponent<PlayerHealth>().TakeDamage(-amountAmmo);
                    break;
                case pickupselection.ammo:
                    other.transform.GetChild(0).GetComponent<playershoiot>().AddBullets(amountAmmo);
                    break;
                case pickupselection.time:
                    gamemanager.instance.AddTime(amountTime);
                    break;
            }
            other.transform.GetChild(0).GetComponent<playershoiot>().AddBullets(amountAmmo);
            Destroy(this.gameObject);
        }
    }
}
