using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField]
    float NoteSpeed = 8;

    // ノーツのポイントと増えるコンボ数をBigInteger型で定義
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
            if (DogAnimation.selectedDogType == "ダックスフント")
            {
                NoteSpeed *= 1.3f;
            }
            if (DogAnimation.selectedDogType == "柴犬")
            {
                NoteSpeed *= 0.8f;
            }
        }
        else
        {
            if (DogAnimation2P.selectedDogType2 == "ダックスフント")
            {
                NoteSpeed *= 1.3f;
            }
            if (DogAnimation2P.selectedDogType2 == "柴犬")
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
