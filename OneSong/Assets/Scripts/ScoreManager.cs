using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField, Header("スコア")]
    public BigInteger m_Score = 0;
    private string[] m_Suffixes= { "肉", "万", "億", "兆", "京", "垓", "𥝱", "穣", "溝", "澗", "正", "載", "極", "恒河沙", "阿僧祇", "那由他", "不可思議", "無量大数" };
    private float scoreMultiplier = 1f;

    [SerializeField,Header("スコアテキスト")]
    private Text m_ScoreText = null;
    [SerializeField, Header("プレイヤー1かどうか")]
    private bool isPlayer1;

    public void IncreaseScore(int points)
    {
        m_Score += points;
        if (isPlayer1)
        {
            if (DogAnimation.selectedDogType == "ダックスフント")
            {
                scoreMultiplier = 2929.9f;
            }
            else if (DogAnimation.selectedDogType == "柴犬")
            {
                scoreMultiplier = 0.09f;
            }
            else
            {
                scoreMultiplier = 1f;
            }
        }
        else
        {
            if (DogAnimation2P.selectedDogType2 == "ダックスフント")
            {
                scoreMultiplier = 2929.9f;
            }
            else if (DogAnimation2P.selectedDogType2 == "柴犬")
            {
                scoreMultiplier = 0.09f;
            }
            else
            {
                scoreMultiplier = 1f;
            }
        }
        m_Score += (BigInteger)(points * scoreMultiplier);
        UpdateScoreText();
        Debug.Log(m_Score);

    }
    public void DoubleScore()
    {
        m_Score *= 29; // スコアを倍増
        UpdateScoreText(); // スコアテキストを更新
    }

    void UpdateScoreText()
    {
        BigInteger score = m_Score;
        string formattedScore = "";

        // スコアが0の場合はそのまま0を表示
        if (score == 0)
        {
            formattedScore = "0";
        }
        else
        {
            // 各桁のポイントを格納するリスト
            List<BigInteger> scoreDigits = new List<BigInteger>();

            // スコアの各桁をリストに追加
            while (score > 0)
            {
                scoreDigits.Add(score % 10000);
                score /= 10000;
            }

            // リストの要素数から最上位の桁を求める
            int numberOfDigits = scoreDigits.Count;

            // 各桁のポイントを文字列に変換
            for (int i = numberOfDigits - 1; i >= 0; i--)
            {
                // 桁の文字列
                string digitString = scoreDigits[i].ToString();

                // 先頭の0を除去
                digitString = digitString.TrimStart('0');

                // 各桁の右端に対応する文字を追加
                if (i > 0 && !string.IsNullOrEmpty(digitString))
                {
                    digitString += m_Suffixes[i];
                }
                else if (i == 0 && !string.IsNullOrEmpty(digitString))
                {
                    digitString += "肉";
                }

                formattedScore += digitString;
            }
        }

        m_ScoreText.text = formattedScore;
    }
}


