using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static bool firstTime1;
    public static bool firstTime2;
    public static bool firstTime3;
    public static bool firstTime4;
    public static bool firstTime5;
    public static bool firstTime6;

    public List<AudioClip> HouseDoor;
    public List<AudioClip> Hand;
    public List<AudioClip> CaveEntrance;
    public List<AudioClip> CaveOut;
    public List<AudioClip> Door;
    //public List<AudioClip> HouseDoor;


    private void Start()
    {
        firstTime1 = false;
        firstTime2 = false;
        firstTime3 = false;
        firstTime4 = false;
        firstTime5 = false;
        firstTime6 = false;

       
    }

    IEnumerator InHouseTalk()
    {
        print(gameObject.name);

        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().clip = HouseDoor[0];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(4);
        GetComponent<AudioSource>().clip = HouseDoor[1];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(4);
        GetComponent<AudioSource>().clip = HouseDoor[2];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10);
        GetComponent<AudioSource>().clip = HouseDoor[3];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(5);
        GetComponent<AudioSource>().clip = HouseDoor[4];
        GetComponent<AudioSource>().Play();

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!firstTime1)
            {
                StartCoroutine(InHouseTalk());
                firstTime1 = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (gameObject.name)
            {

                case "Hand":
                    if (!firstTime3)
                    {
                        StartCoroutine(HandEnum());
                        firstTime3 = true;
                    }
                    break;

                case "CaveEntrance":
                    if (!firstTime4)
                    {
                        StartCoroutine(CaveEntranceEnum());
                        firstTime4 = true;
                    }
                    break;

               
                case "Door":
                    if (!firstTime6)
                    {
                        StartCoroutine(DoorEnum());
                        firstTime6 = true;
                    }
                    break;
            }
        }
    }


    IEnumerator HandEnum()
    {
        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().clip = Hand[0];
        GetComponent<AudioSource>().Play();
    }

    IEnumerator CaveEntranceEnum()
    {
        yield return new WaitForSeconds(3);
        GetComponent<AudioSource>().clip = CaveEntrance[0];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10);
        GetComponent<AudioSource>().clip = CaveEntrance[1];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10);
        GetComponent<AudioSource>().clip = CaveEntrance[2];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(10);
        GetComponent<AudioSource>().clip = CaveEntrance[3];
        GetComponent<AudioSource>().Play();
    }

    IEnumerator DoorEnum()
    {
        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().clip = Door[0];
        GetComponent<AudioSource>().Play();
     
    }
    public void Sound()
    {
        GetComponent<AudioSource>().clip = CaveOut[0];
        GetComponent<AudioSource>().Play();
    }
    
}
