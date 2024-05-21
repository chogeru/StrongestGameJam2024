using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Image timerImage; // タイマーのImageコンポーネント

    // タイマーの更新
    public void UpdateTimer(float remainingTime, float totalDuration)
    {
        // 残り時間の割合を計算
        float fillAmount = remainingTime / totalDuration;

        // タイマーの塗りつぶしを更新
        timerImage.fillAmount = fillAmount;
    }
}
