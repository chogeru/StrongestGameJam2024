using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DogAnimation : MonoBehaviour
{
    [SerializeField, Header("���̉摜���i�[����z��")]
    private Sprite[] m_DonSprites;
    [SerializeField, Header("�L�����N�^�[�̉摜���i�[����ImageObj")]
    private Image m_CharacterImages;
    [SerializeField]
    public static string selectedDogType;

    public static string m_Player1DogType;
    public static string m_Player2DogType;

    public static bool isPlayer1;

    [SerializeField,Header("���I����ʂ̃L�����o�X")]
    public GameObject m_DogSelectionCanvas;
    [SerializeField, Header("���̐�����\������e�L�X�g")]
    private Text m_DogDescriptionText;
    [SerializeField, Header("�Q�[���V�[���̌��̉摜")]
    private Image m_DogImage; 
    [SerializeField,Header("�Q�[���V�[��")]
    public GameObject m_GameScreen;
    [SerializeField, Header("BGM")]
    private GameObject m_BGMObj;
    [SerializeField]
    private NotesManager m_NotesManager;
    int randomDogIndex;
    [SerializeField,Header("�I�[�f�B�I�\�[�X")]
    private AudioSource m_AudioSource;
    [SerializeField,Header("SEClip")]
    private AudioClip m_AudioClip;
    [SerializeField,Header("Judge")]
    private Judge judge;
    private bool isDogSet = false;
    private void Start()
    {
        StartCoroutine(AnimateDogSelection());
    }

    IEnumerator AnimateDogSelection()
    {
        yield return new WaitForSeconds(1.0f);
        int randamIndex = UnityEngine.Random.Range(0, m_DonSprites.Length);
        m_CharacterImages.sprite = m_DonSprites[randamIndex];
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            randomDogIndex = UnityEngine.Random.Range(0, m_DonSprites.Length);
            m_CharacterImages.sprite = m_DonSprites[randomDogIndex];
            elapsedTime += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        // �����_���ɑI���������̃^�C�v�ɉ����Đ�p�̃��\�b�h���Ăяo��
        string dogType = GetDogType(randomDogIndex);
        selectedDogType = dogType;
        switch (dogType)
        {
            case "�n�X�L�[":
                SpecialMethodForCorgi();
                break;
            case "�_�b�N�X�t���g":
                SpecialMethodForChihuahua();
                break;
            case "�Č�":
                SpecialMethodForShibaInu();
                break;
            case "�|�����j�A��":
                SpecialMethodForPomeranian();
                break;
            case "���g���[�o�[":
                SpecialMethodForRetriever();
                break;
            case "�g�C�v�[�h��":
                SpecialMethodForToyPoodle();
                break;
            default:
                break;
        }
        m_DogImage.sprite = m_DonSprites[randomDogIndex];
      
        isDogSet = true;
    }
    private void Update()
    {
        // ���̉摜���Z�b�g���ꂽ��A�X�y�[�X�L�[�������ꂽ�Ƃ��̂ݓ���
        if (isDogSet && Input.GetKeyDown(KeyCode.A))
        {
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
            m_DogSelectionCanvas.SetActive(false);// �L�����o�X���\���ɂ���
            m_GameScreen.SetActive(true);  // �Q�[����ʂ��A�N�e�B�u�ɂ���
            m_BGMObj.SetActive(false);
            m_NotesManager.Load();
            
        }
    }
    // ���̃^�C�v�ɉ����Đ�p�̃��\�b�h��Ԃ�
    private string GetDogType(int index)
    {
        // �����ł͊ȒP���̂��߁A�C���f�b�N�X�𗘗p���Č��̃^�C�v�����蓖�Ă�
        switch (index)
        {
            case 0: return "�n�X�L�[";
            case 1: return "�_�b�N�X�t���g";
            case 2: return "�Č�";
            case 3: return "�|�����j�A��";
            case 4: return "���g���[�o�[";
            case 5: return "�g�C�v�[�h��";
            default: return "";
        }
    }

    private void SpecialMethodForCorgi()
    {
        m_DogDescriptionText.text = "�n�X�L�[�͒����Ŋ����Ȑ��i����������I�T��A���ł�����H�ׂ���A�{�[�i�X�_�����炦��";
    }

    private void SpecialMethodForChihuahua()
    {
        m_DogDescriptionText.text = "�_�b�N�X�t���g�͏��^���ŗE���Œ����Ȑ��i�������킾��I\n���������������Ă��邯�ǁA�o�����Ă�����|�C���g�͏オ���";
    }

    private void SpecialMethodForShibaInu()
    {
        m_DogDescriptionText.text = "�Č��͗E���Œ����Ȑ��i��������ł��킢����I\n�������x�������Ă��邯�ǁA�N�x�����������Ⴄ����|�C���g�͉������";
    }

    private void SpecialMethodForPomeranian()
    {
        m_DogDescriptionText.text = "�|�����j�A���͊����Ō����炵����I\n10�J�A���ŐH�ׂ���A10�b�Ԏ����ł�����H�ׂ��Ⴄ��I�H������V���ˁI";
    }

    private void SpecialMethodForRetriever()
    {
        m_DogDescriptionText.text = "���g���[�o�[�͒m�I�ŗD�������i�������Ă��I\n10��A���ł�����H�ׂ���A�_���{�X�ɑ����Ă�����";
    }

    private void SpecialMethodForToyPoodle()
    {
        m_DogDescriptionText.text = "�g�C�v�[�h���͒m�I�ň���[���A������ɒ����Ȑ��i����I\n���~�X���Ă����v�I�g�C�v�[�h���������Ă����I";
    }

}
