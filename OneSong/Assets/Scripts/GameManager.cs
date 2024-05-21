using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxScore;
    public int ratioScore;

    public int songID;
    public float noteSpeed;

    public bool Start;
    public float StartTime;

    public bool isPlayer1End=false;
    public bool isPlayerEnd2=false;

    [SerializeField, Header("���U���g���")]
    private GameObject m_ResultScreen;
    [SerializeField,Header("���U���g�e�L�X�g")]
    private Text m_ResultText;
    [SerializeField]
    private float m_TransitionTime=0;

    [SerializeField,Header("score�}�l�[�W���[")]
    private ScoreManager m_ScoreManager;
    [SerializeField,Header("score�}�l�[�W���[2")]
    private ScoreManager m_ScoreManager2;
    private void Update()
    {
        if(isPlayer1End&&isPlayerEnd2)
        {
            m_TransitionTime += Time.deltaTime;
        }
        if(m_TransitionTime>2)
        {
            if(m_ScoreManager.m_Score>m_ScoreManager2.m_Score)
            {
                m_ResultText.text = "1P�̏���";
            }
            if (m_ScoreManager.m_Score < m_ScoreManager2.m_Score)
            {
                m_ResultText.text = "2P�̏���";
            }
            GameResult();
        }
    }
    private void GameResult()
    {
        if(m_ResultScreen != null)
        {
            m_ResultScreen.SetActive(true);
        }
        else
        {
            Debug.Log("���U���g��ʂ�����܂���");
        }
    }

}