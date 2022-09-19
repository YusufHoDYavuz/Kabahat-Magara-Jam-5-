using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoss : MonoBehaviour
{
    public GameObject wife, mobilya, door, caveOutDoor;

    
    public void KillTheBoss()
    {
        wife.SetActive(true);
        mobilya.SetActive(true);

        door.SetActive(false);
        caveOutDoor.SetActive(false);
    }
}
