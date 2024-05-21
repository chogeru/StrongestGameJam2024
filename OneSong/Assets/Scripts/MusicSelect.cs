using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Music;
    [SerializeField]
    private GameObject m_MusicSelectScene;
    public void NowMusic()
    {
        m_Music.SetActive(true);
        m_MusicSelectScene.SetActive(false);
    }
}
