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

    [SerializeField, Header("リザルト画面")]
    private GameObject m_ResultScreen;
    [SerializeField,Header("リザルトテキスト")]
    private Text m_ResultText;
    [SerializeField]
    private float m_TransitionTime=0;

    [SerializeField,Header("scoreマネージャー")]
    private ScoreManager m_ScoreManager;
    [SerializeField,Header("scoreマネージャー2")]
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
                m_ResultText.text = "1Pの勝ち";
            }
            if (m_ScoreManager.m_Score < m_ScoreManager2.m_Score)
            {
                m_ResultText.text = "2Pの勝ち";
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
            Debug.Log("リザルト画面がありません");
        }
    }

}