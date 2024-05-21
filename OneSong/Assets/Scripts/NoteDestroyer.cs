using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDestroyer : MonoBehaviour
{
    [SerializeField]
    private Judge judge;
    [SerializeField, Header("コンボマネージャー")]
    private ComboManager comboManager;
    [SerializeField, Header("犬画像表示")]
    private DogImageDisplay dogImageDisplay;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            MissNote();
            Destroy(collision.gameObject);  // ノーツを破棄
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
