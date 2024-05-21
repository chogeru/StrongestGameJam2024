using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using R3;

public class DifficultySelectionUI : MonoBehaviour
{
    [SerializeField, Header("難易度イメージオブジェ")]
    private Image[] m_DifficultyImages;
    private int m_SelectedIndex = 0;
    private float m_PressTime = 0f;
    [SerializeField, Header("選択状態のimageの最大サイズ")]
    private float m_SelectedScale = 1.2f;
    [SerializeField,Header("キャラクターセット画面")]
    private GameObject m_CharacterSelectionCanvas;
    string songName = ""; // 曲名を格納する変数
    [SerializeField,Header("SE用AudioSouce")]
    private AudioSource m_AudioSource;
    [SerializeField ,Header("SEクリップ")]
    private AudioClip m_AudioClip;
    [SerializeField]
    private NotesManager notesManager;
    private void Start()
    {
        UpdateSelectedImage();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_PressTime = Time.time; // スペースキーが押された時間を記録
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
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
                EasySelected();
                break;
            case 1:
                NormalSelected();
                break;
            case 2:
                HardSelected();
                break;
            case 3:
                Demon();
                break;
            case 4:
                SuperHard();
                break;
        }
        gameObject.SetActive(false);
        m_CharacterSelectionCanvas.gameObject.SetActive(true);
        m_AudioSource.clip = m_AudioClip;
        m_AudioSource.Play();
    }
    void EasySelected()
    {
        songName = "ゲームジャム音楽簡単";
        notesManager.LoadSong(songName);
        Debug.Log("イージ-");
    }

    void NormalSelected()
    {
        songName = "ゲームジャム音楽普通";
        notesManager.LoadSong(songName);
        Debug.Log("ノーマル");
    }

    void HardSelected()
    {
        songName = "ゲームジャム音楽むずかしい";
        notesManager.LoadSong(songName);
    }
    void Demon()
    {
        songName = "ゲームジャム音楽鬼";
        notesManager.LoadSong(songName);
    }
    void SuperHard()
    {
        songName = "ゲームジャム音楽めちゃむず";
        notesManager.LoadSong(songName);
    }
    public void SetMusic()
    {
        notesManager.LoadSong(songName);
    }
}
