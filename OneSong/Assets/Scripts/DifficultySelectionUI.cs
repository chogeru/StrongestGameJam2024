using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using R3;

public class DifficultySelectionUI : MonoBehaviour
{
    [SerializeField, Header("��Փx�C���[�W�I�u�W�F")]
    private Image[] m_DifficultyImages;
    private int m_SelectedIndex = 0;
    private float m_PressTime = 0f;
    [SerializeField, Header("�I����Ԃ�image�̍ő�T�C�Y")]
    private float m_SelectedScale = 1.2f;
    [SerializeField,Header("�L�����N�^�[�Z�b�g���")]
    private GameObject m_CharacterSelectionCanvas;
    string songName = ""; // �Ȗ����i�[����ϐ�
    [SerializeField,Header("SE�pAudioSouce")]
    private AudioSource m_AudioSource;
    [SerializeField ,Header("SE�N���b�v")]
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
            m_PressTime = Time.time; // �X�y�[�X�L�[�������ꂽ���Ԃ��L�^
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
        }
        // �X�y�[�X�L�[�������ꂽ��
        else if (Input.GetKeyUp(KeyCode.A))
        {
            // �X�y�[�X�L�[��1�b�ȏ㉟����Ă����ꍇ
            if (Time.time - m_PressTime >= 0.3f)
            {
                // �I������Ă����Փx�̊֐������s
                ExecuteSelectedFunction();
            }
            else // 1�b�����ŃX�y�[�X�L�[�������ꂽ�ꍇ
            {
                // ���̓�Փx��I��
                m_SelectedIndex = (m_SelectedIndex + 1) % m_DifficultyImages.Length;
                // �I�����ꂽ��Փx��Image���X�V
                UpdateSelectedImage();
            }
        }
    }
    // �I������Ă����Փx��Image���X�V����֐�
    void UpdateSelectedImage()
    {
        // ���ׂĂ̓�Փx��Image�����̃T�C�Y�ɖ߂�
        foreach (Image image in m_DifficultyImages)
        {
            // ��I����Ԃ̉摜�ɐ؂�ւ���Ȃǂ̏������s��
            image.transform.localScale = Vector3.one; // ���̃T�C�Y�ɖ߂�
        }

        // �I������Ă����Փx��Image���g�傷��
        m_DifficultyImages[m_SelectedIndex].transform.localScale = new Vector3(m_SelectedScale, m_SelectedScale, 1f);
    }
    // �I������Ă����Փx�̊֐������s����֐�
    void ExecuteSelectedFunction()
    {
        // selectedIndex�ɑΉ������Փx�̊֐������s����
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
        songName = "�Q�[���W�������y�ȒP";
        notesManager.LoadSong(songName);
        Debug.Log("�C�[�W-");
    }

    void NormalSelected()
    {
        songName = "�Q�[���W�������y����";
        notesManager.LoadSong(songName);
        Debug.Log("�m�[�}��");
    }

    void HardSelected()
    {
        songName = "�Q�[���W�������y�ނ�������";
        notesManager.LoadSong(songName);
    }
    void Demon()
    {
        songName = "�Q�[���W�������y�S";
        notesManager.LoadSong(songName);
    }
    void SuperHard()
    {
        songName = "�Q�[���W�������y�߂���ނ�";
        notesManager.LoadSong(songName);
    }
    public void SetMusic()
    {
        notesManager.LoadSong(songName);
    }
}
