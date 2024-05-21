using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboManager : MonoBehaviour
{

    [SerializeField]
    public int m_Combo = 0;
    [SerializeField]
    private Text m_ComboText = null;
    [SerializeField,Header("scoreマネージャー")]
    private ScoreManager m_ScoreManager;
    [SerializeField, Header("プレイヤーiかどうか")]
    private bool isPlayer1;
    public void IncreaseCombo(int points)
    {
        m_Combo += points;
        CheckForCorgiBonus();
        UpdateComboText();
    }
    private void CheckForCorgiBonus()
    {
        if (isPlayer1)
        {
            if (DogAnimation.selectedDogType == "ハスキー" && m_Combo % 5 == 0 && m_Combo != 0)
            {
                m_ScoreManager.IncreaseScore(10000000);
                UpdateComboText();
            }
        }
        else
        {
            if(DogAnimation2P.selectedDogType2 == "ハスキー" && m_Combo % 5 == 0 && m_Combo != 0)
            {
                m_ScoreManager.IncreaseScore(10000000);
                UpdateComboText();
            }
        }

    }
    public void ResetCombo()
    {
        m_Combo = 0;
        UpdateComboText();
    }


    public void UpdateComboText()
    {
        long combo = m_Combo;
        string formattedCombo = "";

        // コンボが0の場合はそのまま0を表示
        if (combo == 0)
        {
            formattedCombo = "0";
        }
        else
        {
            // 各桁のコンボポイントをリストに追加
            List<long> comboDigits = new List<long>();

            // コンボの各桁をリストに追加
            while (combo > 0)
            {
                comboDigits.Add(combo % 10000);
                combo /= 10000;
            }

            // リストの要素数から最上位の桁を求める
            int numberOfDigits = comboDigits.Count;

            // 各桁のポイントを文字列に変換
            for (int i = numberOfDigits - 1; i >= 0; i--)
            {
                // 桁の文字列
                string digitString = comboDigits[i].ToString();

                // 先頭の0を除去
                digitString = digitString.TrimStart('0');

                // 各桁の右端に対応する文字を追加
                if (!string.IsNullOrEmpty(digitString))
                {
                    if (i > 0)
                    {
                        // コンボ以外の桁
                        formattedCombo += digitString + ",";
                    }
                    else
                    {
                        // 一番右端の文字のコンボ
                        formattedCombo += digitString + "コンボ";
                    }
                }
            }
        }

        m_ComboText.text = formattedCombo;
    }
}

