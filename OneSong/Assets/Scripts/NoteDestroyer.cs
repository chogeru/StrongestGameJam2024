using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDestroyer : MonoBehaviour
{
    [SerializeField]
    private Judge judge;
    [SerializeField, Header("�R���{�}�l�[�W���[")]
    private ComboManager comboManager;
    [SerializeField, Header("���摜�\��")]
    private DogImageDisplay dogImageDisplay;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            MissNote();
            Destroy(collision.gameObject);  // �m�[�c��j��
            StartCoroutine(dogImageDisplay.NoteDestroyDogImage());
        }
    }
    private void MissNote()
    {
        Debug.Log("Miss");
        comboManager.m_Combo = 0;
        comboManager.UpdateComboText();
    }
}
