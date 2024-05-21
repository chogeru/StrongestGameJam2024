using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DogImageDisplay : MonoBehaviour
{
    [SerializeField] private Image dogImageDisplay;
    [SerializeField] private Sprite[] dogSprites;
    [SerializeField] private Sprite[] destroydogSprites;
    [SerializeField]
    private Judge judgeScript;
    public bool isHit=false;
    public bool isPlayer1=false;
    private void Start()
    {
        dogImageDisplay.enabled = false;
    }
    private void Update()
    {
        if (isHit)
        {
            StartCoroutine(DisplayDogImage());
            isHit = false;
        }
    }
    public IEnumerator DisplayDogImage()
    {
        if(isPlayer1)
        {
            string currentDogType = DogAnimation.selectedDogType;
            int dogIndex = GetDogIndex(currentDogType);
            dogImageDisplay.sprite = dogSprites[dogIndex];
            dogImageDisplay.enabled = true;
            yield return new WaitForSeconds(0.3f);
            dogImageDisplay.enabled = false;
        }
        else
        {
            string currentDogType = DogAnimation2P.selectedDogType2;
            int dogIndex = GetDogIndex(currentDogType);
            dogImageDisplay.sprite = dogSprites[dogIndex];
            dogImageDisplay.enabled = true;
            yield return new WaitForSeconds(0.3f);
            dogImageDisplay.enabled = false;
        }
    }
    public IEnumerator NoteDestroyDogImage()
    {
        if (isPlayer1)
        {
            string currentDogType = DogAnimation.selectedDogType;
            int dogIndex = GetDogIndex(currentDogType);
            dogImageDisplay.sprite = destroydogSprites[dogIndex];
            dogImageDisplay.enabled = true;
            yield return new WaitForSeconds(0.3f);
            dogImageDisplay.enabled = false;
        }
        else
        {
            string currentDogType = DogAnimation2P.selectedDogType2;
            int dogIndex = GetDogIndex(currentDogType);
            dogImageDisplay.sprite = destroydogSprites[dogIndex];
            dogImageDisplay.enabled = true;
            yield return new WaitForSeconds(0.3f);
            dogImageDisplay.enabled = false;
        }
    }
    private int GetDogIndex(string dogType)
    {
        switch (dogType)
        {
            case "�n�X�L�[": return 0;
            case "�_�b�N�X�t���g": return 1;
            case "�Č�": return 2;
            case "�|�����j�A��": return 3;
            case "���g���[�o�[": return 4;
            case "�g�C�v�[�h��": return 5;
            default: return -1; 
        }
    }
}
