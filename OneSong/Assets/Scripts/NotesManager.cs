using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;

}
[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NotesManager : MonoBehaviour
{
    //ノーツの数
    public int m_NoteNum;
    //何番のレーンに落ちてくるか
    public List<int> m_LaneNum = new List<int>();
    //ノーツのタイプ
    public List<int> m_NoteType = new List<int>();
    //ノーツが判定線と重なる時間
    public List<float> m_NotesTime = new List<float>();
    public List<GameObject> m_NotesObj = new List<GameObject>();

    [SerializeField,Header("ノーツの左右の位置")]
    private int m_HorizontalPosition;

    [SerializeField]
    public float m_NotesSpeed;
    [SerializeField]
    public GameObject[] notePrefabs;
    [SerializeField]
    public GameObject[] notePrefabs2;
    [SerializeField]
    public string m_MusicName;
    void OnEnable()
    {
        m_NoteNum = 0;//総ノーツ数を0に
    }
    public void LoadSong(string songName)
    {
        m_MusicName = songName; //曲名を設定
    }
    public void Load()
    {

        string inputString = Resources.Load<TextAsset>(m_MusicName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        m_NoteNum = inputJson.notes.Length;
        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            // ランダムにノーツの種類を選択
            int randomNoteIndex = UnityEngine.Random.Range(0, notePrefabs.Length);
            int randomNoteIndex2 = UnityEngine.Random.Range(0, notePrefabs.Length);

            GameObject selectedPrefab = notePrefabs[randomNoteIndex];
            GameObject selectedPrefab2 = notePrefabs2[randomNoteIndex2];
            
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            m_NotesTime.Add(time);
            m_NoteType.Add(inputJson.notes[i].type);

            // 左右それぞれの位置にノーツを生成
            float leftX = inputJson.notes[i].block - 4.5f;
            float rightX = inputJson.notes[i].block + 4.5f;

            float y = m_NotesTime[i] * m_NotesSpeed;

            // 左側のノーツ生成
            m_NotesObj.Add(Instantiate(selectedPrefab, new Vector3(leftX, y, 0), Quaternion.identity));

            // 右側のノーツ生成
            m_NotesObj.Add(Instantiate(selectedPrefab2, new Vector3(rightX, y, 0), Quaternion.identity));
        }
    }
}