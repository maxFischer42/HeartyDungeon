using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnabler : MonoBehaviour
{
    public AudioSource m_audio;
    float dis = 15;

    void Update()
    {
        Vector3 distance = GameObject.Find("Player").transform.position - transform.position;

        if (distance.magnitude < dis)
        {
            m_audio.enabled = true;
        }
        else
        {
            m_audio.enabled = false;
        }
    }
}
