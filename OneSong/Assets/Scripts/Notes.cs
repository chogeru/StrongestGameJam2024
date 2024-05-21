using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField]
    float NoteSpeed = 8;

    // �m�[�c�̃|�C���g�Ƒ�����R���{����BigInteger�^�Œ�`
    [SerializeField]
    public int m_NotePoints = 10;
    [SerializeField]
    public int m_ComboCount = 10;
    [SerializeField]
    private bool isPlayer;

    private void Start()
    {
        if (isPlayer)
        {
            if (DogAnimation.selectedDogType == "�_�b�N�X�t���g")
            {
                NoteSpeed *= 1.3f;
            }
            if (DogAnimation.selectedDogType == "�Č�")
            {
                NoteSpeed *= 0.8f;
            }
        }
        else
        {
            if (DogAnimation2P.selectedDogType2 == "�_�b�N�X�t���g")
            {
                NoteSpeed *= 1.3f;
            }
            if (DogAnimation2P.selectedDogType2 == "�Č�")
            {
                NoteSpeed *= 0.8f;
            }
        }
    }

    void Update()
    {
        transform.Translate(UnityEngine.Vector3.down * NoteSpeed * Time.deltaTime);
    }
}
