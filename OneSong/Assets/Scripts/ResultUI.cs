using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultUI : MonoBehaviour
{
    [SerializeField, Header("��Փx�C���[�W�I�u�W�F")]
    private Image[] m_DifficultyImages;
    private int m_SelectedIndex = 0;
    private float m_PressTime = 0f;
    [SerializeField, Header("�I����Ԃ�image�̍ő�T�C�Y")]
    private float m_SelectedScale = 1.2f;
    [SerializeField, Header("BGM")]
    private GameObject m_BGMObj;
    private AudioSource m_AudioSource;

    [SerializeField,Header("�N���A����BBGM")]
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
            m_PressTime = Time.time; // �X�y�[�X�L�[�������ꂽ���Ԃ��L�^
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
                GameExit();
                break;
            case 1:
                Retry();
                break;
        }
    }
    void GameExit()
    {
        Application.Quit();//�Q�[���v���C�I��
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
