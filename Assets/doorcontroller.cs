using UnityEngine;
using DG.Tweening;
public class doorcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameevent.instance.ondoortriggerenter += OpenDoor;
        gameevent.instance.ondoortriggeredexit += CloseDoor;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OpenDoor()
    {
        //transform.Translate(new Vector3(60.63f, 18.88f, -6.92f)); para moverla de golpe y se teletransporta
        transform.DOMoveY(3,2);
    }
    void CloseDoor()
    {
        //transform.Translate(new Vector3(-60.63f, -18.88f, 6.92f));
        transform.DOMoveY(22.7f, 2);
    }

    // void OpenDoor(9
    //{
    //gameevent.instance.ondoortriggerenter -= Opendoor;
    //}
    //esto sirve cuando el objeto se destruye o ya no exite en el mapa. También tenemos que desuscribirnos.
}
