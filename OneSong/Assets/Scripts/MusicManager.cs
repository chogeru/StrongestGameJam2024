using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource m_AudioSource;
    [SerializeField]
    AudioClip m_Music;
    [SerializeField, Header("ノーツマネージャー")]
    private NotesManager m_NotesManager;
    [SerializeField, Header("ゲームマネージャー")]
    private GameManager m_GameManager;
    public TimerUI timerUI; // タイマーUIのスクリプト
    [SerializeField]
    private bool isPlayer1;
    [SerializeField]
    private bool isAudioStop;
    void Start()
    {
        m_GameManager.Start = false;
        m_AudioSource = GetComponent<AudioSource>();
        m_Music = (AudioClip)Resources.Load("Musics/" + m_NotesManager.m_MusicName);
        m_AudioSource.clip = m_Music;
        isAudioStop = false;
        if (isPlayer1)
        {
            if (DogAnimation.selectedDogType == "ダックスフント")
            {
                m_AudioSource.pitch *= 1.2f;
            }
            if (DogAnimation.selectedDogType == "柴犬")
            {
                m_AudioSource.pitch *= 0.8f;
            }
        }
        else
        {
            if (DogAnimation2P.selectedDogType2 == "ダックスフント")
            {
                m_AudioSource.pitch *= 1.2f;
            }
            if (DogAnimation2P.selectedDogType2 == "柴犬")
            {
                m_AudioSource.pitch *= 0.8f;
            }
        }
        if (!m_AudioSource.isPlaying)
        {
            m_GameManager.Start = true;
            m_GameManager.StartTime = Time.time;
            m_AudioSource.Play();
        }
    }

    void Update()
    {
        if (isAudioStop)
            return;
        // 曲の再生時間から残り時間を計算
        float remainingTime = m_AudioSource.clip.length - m_AudioSource.time;
        // タイマーUIの更新
        timerUI.UpdateTimer(remainingTime, m_AudioSource.clip.length);
        if (remainingTime <= 0)
        {

            if (isPlayer1)
            {
                m_GameManager.isPlayer1End = true;
            }
            else
            {
                m_GameManager.isPlayerEnd2 = true;
            }
            isAudioStop = true;
        }

    }
}