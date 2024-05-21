using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DogAnimation : MonoBehaviour
{
    [SerializeField, Header("犬の画像を格納する配列")]
    private Sprite[] m_DonSprites;
    [SerializeField, Header("キャラクターの画像を格納するImageObj")]
    private Image m_CharacterImages;
    [SerializeField]
    public static string selectedDogType;

    public static string m_Player1DogType;
    public static string m_Player2DogType;

    public static bool isPlayer1;

    [SerializeField,Header("犬選択画面のキャンバス")]
    public GameObject m_DogSelectionCanvas;
    [SerializeField, Header("犬の説明を表示するテキスト")]
    private Text m_DogDescriptionText;
    [SerializeField, Header("ゲームシーンの犬の画像")]
    private Image m_DogImage; 
    [SerializeField,Header("ゲームシーン")]
    public GameObject m_GameScreen;
    [SerializeField, Header("BGM")]
    private GameObject m_BGMObj;
    [SerializeField]
    private NotesManager m_NotesManager;
    int randomDogIndex;
    [SerializeField,Header("オーディオソース")]
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
        // ランダムに選択した犬のタイプに応じて専用のメソッドを呼び出す
        string dogType = GetDogType(randomDogIndex);
        selectedDogType = dogType;
        switch (dogType)
        {
            case "ハスキー":
                SpecialMethodForCorgi();
                break;
            case "ダックスフント":
                SpecialMethodForChihuahua();
                break;
            case "柴犬":
                SpecialMethodForShibaInu();
                break;
            case "ポメラニアン":
                SpecialMethodForPomeranian();
                break;
            case "レトリーバー":
                SpecialMethodForRetriever();
                break;
            case "トイプードル":
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
        // 犬の画像がセットされた後、スペースキーが押されたときのみ動作
        if (isDogSet && Input.GetKeyDown(KeyCode.A))
        {
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
            m_DogSelectionCanvas.SetActive(false);// キャンバスを非表示にする
            m_GameScreen.SetActive(true);  // ゲーム画面をアクティブにする
            m_BGMObj.SetActive(false);
            m_NotesManager.Load();
            
        }
    }
    // 犬のタイプに応じて専用のメソッドを返す
    private string GetDogType(int index)
    {
        // ここでは簡単化のため、インデックスを利用して犬のタイプを割り当てる
        switch (index)
        {
            case 0: return "ハスキー";
            case 1: return "ダックスフント";
            case 2: return "柴犬";
            case 3: return "ポメラニアン";
            case 4: return "レトリーバー";
            case 5: return "トイプードル";
            default: return "";
        }
    }

    private void SpecialMethodForCorgi()
    {
        m_DogDescriptionText.text = "ハスキーは忠実で活発な性格を持つ犬だよ！５回連続でお肉を食べたら、ボーナス点がもらえる";
    }

    private void SpecialMethodForChihuahua()
    {
        m_DogDescriptionText.text = "ダックスフントは小型犬で勇敢で忠実な性格を持つ犬種だよ！\nお肉が早く落ちてくるけど、出来立てだからポイントは上がるよ";
    }

    private void SpecialMethodForShibaInu()
    {
        m_DogDescriptionText.text = "柴犬は勇敢で忠実な性格を持つ犬種でかわいいよ！\nお肉が遅く落ちてくるけど、鮮度が下がっちゃうからポイントは下がるよ";
    }

    private void SpecialMethodForPomeranian()
    {
        m_DogDescriptionText.text = "ポメラニアンは活発で賢いらしいよ！\n10開連続で食べたら、10秒間自動でお肉を食べちゃうよ！食いしん坊だね！";
    }

    private void SpecialMethodForRetriever()
    {
        m_DogDescriptionText.text = "レトリーバーは知的で優しい性格を持ってるよ！\n10回連続でお肉を食べたら、点が倍々に増えていくよ";
    }

    private void SpecialMethodForToyPoodle()
    {
        m_DogDescriptionText.text = "トイプードルは知的で愛情深く、飼い主に忠実な性格だよ！\n一回ミスしても大丈夫！トイプードルが助けてくれる！";
    }

}
