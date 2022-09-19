using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{

    public List<AudioClip> WolfSoudn;

    private void OnEnable()
    {
        Wolf();
    }
    public void Wolf()
    {
        StartCoroutine(InHouseTalk());
    }

    IEnumerator InHouseTalk()
    {
        yield return new WaitForSeconds(5);
        GetComponent<AudioSource>().clip = WolfSoudn[0];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(14);
        GetComponent<AudioSource>().clip = WolfSoudn[1];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(14);
        GetComponent<AudioSource>().clip = WolfSoudn[2];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(14);
        GetComponent<AudioSource>().clip = WolfSoudn[3];
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(14);
        GetComponent<AudioSource>().clip = WolfSoudn[4];
        GetComponent<AudioSource>().Play();

    }
}
