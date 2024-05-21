using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultUI : MonoBehaviour
{
    [SerializeField, Header("難易度イメージオブジェ")]
    private Image[] m_DifficultyImages;
    private int m_SelectedIndex = 0;
    private float m_PressTime = 0f;
    [SerializeField, Header("選択状態のimageの最大サイズ")]
    private float m_SelectedScale = 1.2f;
    [SerializeField, Header("BGM")]
    private GameObject m_BGMObj;
    private AudioSource m_AudioSource;

    [SerializeField,Header("クリア時のBBGM")]
    private AudioClip m_AudioClip;
    private void Start()
    {
        m_BGMObj.SetActive(true);
        m_AudioSource=m_BGMObj.GetComponent<AudioSource>();
        m_AudioSource.clip = m_AudioClip;
        m_AudioSource.Play();
        UpdateSelectedImage();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_PressTime = Time.time; // スペースキーが押された時間を記録
        }
        // スペースキーが離されたら
        else if (Input.GetKeyUp(KeyCode.A))
        {
            // スペースキーが1秒以上押されていた場合
            if (Time.time - m_PressTime >= 0.3f)
            {
                // 選択されている難易度の関数を実行
                ExecuteSelectedFunction();
            }
            else // 1秒未満でスペースキーが離された場合
            {
                // 次の難易度を選択
                m_SelectedIndex = (m_SelectedIndex + 1) % m_DifficultyImages.Length;
                // 選択された難易度のImageを更新
                UpdateSelectedImage();
            }
        }
    }
    // 選択されている難易度のImageを更新する関数
    void UpdateSelectedImage()
    {
        // すべての難易度のImageを元のサイズに戻す
        foreach (Image image in m_DifficultyImages)
        {
            // 非選択状態の画像に切り替えるなどの処理を行う
            image.transform.localScale = Vector3.one; // 元のサイズに戻す
        }

        // 選択されている難易度のImageを拡大する
        m_DifficultyImages[m_SelectedIndex].transform.localScale = new Vector3(m_SelectedScale, m_SelectedScale, 1f);
    }
    // 選択されている難易度の関数を実行する関数
    void ExecuteSelectedFunction()
    {
        // selectedIndexに対応する難易度の関数を実行する
        switch (m_SelectedIndex)
        {
            case 0:
                GameExit();
                break;
            case 1:
                Retry();
                break;
        }
    }
    void GameExit()
    {
        Application.Quit();//ゲームプレイ終了
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
