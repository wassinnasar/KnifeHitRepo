using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource knifeAndKnife;
    [SerializeField]
    private AudioSource knifeAndTarget;
    [SerializeField]
    private AudioSource knifeAndWreck;
   
    public void KnifeAndKnife()
    {
        knifeAndKnife.Play();
    }
    public void KnifeAndTarget()
    {
        knifeAndTarget.Play();
    }
    public void KnifeAndWreck()
    {
        knifeAndWreck.Play();
    }
}
