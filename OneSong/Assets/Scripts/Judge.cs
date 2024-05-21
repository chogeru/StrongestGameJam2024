using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Judge : MonoBehaviour
{
    [SerializeField] NotesManager notesManager;
    [SerializeField] Text comboText;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip hitSound;
    [SerializeField] KeyCode hitKeyCode = KeyCode.Space;
    private AudioSource audioSource;
    public GameObject currentNote;
    [SerializeField, Header("プレイヤー1")]
    private bool isPlayer1;

    public bool isToyPoodleForgivenessUsed = false;

    private bool isPomeranianAutoPlayActive = false;
    private int pomeranianAutoPlayCombo = 0;
    private float pomeranianAutoPlayTimer = 0f;
    private const float AUTO_PLAY_DURATION = 10f;
    [SerializeField, Header("scoreマネージャー")]
    private ScoreManager scoreManager;
    [SerializeField, Header("コンボマネージャー")]
    private ComboManager comboManager;
    private int retrieverCombo = 0;
    [SerializeField]
    DogImageDisplay imageDisplay;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isPlayer1)
        {
            if (DogAnimation.selectedDogType == "ポメラニアン")
            {
                isToyPoodleForgivenessUsed = true;
            }

        }
        else
        {
            if (DogAnimation2P.selectedDogType2 == "ポメラニアン")
            {
                isToyPoodleForgivenessUsed = true;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(hitKeyCode))
        {
            if (currentNote != null)
            {
                if (isPlayer1)
                {
                    if (DogAnimation.selectedDogType == "ポメラニアン")
                    {
                        pomeranianAutoPlayCombo++;
                        if (pomeranianAutoPlayCombo >= 10)
                        {
                            isPomeranianAutoPlayActive = true;
                            pomeranianAutoPlayCombo = 0;
                        }

                    }
                    if (DogAnimation.selectedDogType == "レトリーバー")
                    {
                        retrieverCombo++;
                        if (retrieverCombo >= 10)
                        {
                            scoreManager.DoubleScore(); // スコアを倍増
                            retrieverCombo = 0; // コンボをリセット
                        }
                    }
                }
                else
                {
                    if (DogAnimation2P.selectedDogType2 == "ポメラニアン")
                    {
                        pomeranianAutoPlayCombo++;
                        if (pomeranianAutoPlayCombo >= 10)
                        {
                            isPomeranianAutoPlayActive = true;
                            pomeranianAutoPlayCombo = 0;
                        }

                    }
                    if (DogAnimation2P.selectedDogType2 == "レトリーバー")
                    {
                        retrieverCombo++;
                        if (retrieverCombo >= 10)
                        {
                            scoreManager.DoubleScore(); // スコアを倍増
                            retrieverCombo = 0; // コンボをリセット
                        }
                    }
                }
            }

            if (!isPomeranianAutoPlayActive)
            {
                HitNote();
                Destroy(currentNote);
                currentNote = null;
            }
        }

        if (isPomeranianAutoPlayActive)
        {
            pomeranianAutoPlayTimer += Time.deltaTime;
            if (currentNote != null)
            {
                HitNote();
                Destroy(currentNote);
                currentNote = null;
            }

            if (pomeranianAutoPlayTimer >= AUTO_PLAY_DURATION)
            {
                isPomeranianAutoPlayActive = false;
                pomeranianAutoPlayTimer = 0f;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            currentNote = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentNote)
        {
            if (isToyPoodleForgivenessUsed)
            {
                HitNote();
                Destroy(currentNote);
                isToyPoodleForgivenessUsed = false;
            }
            currentNote = null;
        }
        if (isPlayer1)
        {
            if (DogAnimation.selectedDogType == "ハスキー")
            {

            }
            else if (DogAnimation.selectedDogType == "ダックスフント")
            {

            }
            else if (DogAnimation.selectedDogType == "柴犬")
            {

            }
            else if (DogAnimation.selectedDogType == "ポメラニアン")
            {

            }
            else if (DogAnimation.selectedDogType == "レトリーバー")
            {

            }
            else if (DogAnimation.selectedDogType == "トイプードル")
            {

            }
        }
    }


    private void HitNote()
    {
        if (currentNote != null)
        {

            audioSource.PlayOneShot(hitSound);
            Debug.Log("Hit");
            Notes notes = currentNote.GetComponent<Notes>();
            imageDisplay.isHit = true;
            scoreManager.IncreaseScore(notes.m_NotePoints);
            comboManager.IncreaseCombo(notes.m_ComboCount);
        }
    }
}
