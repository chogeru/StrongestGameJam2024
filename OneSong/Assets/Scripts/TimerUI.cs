using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Image timerImage; // �^�C�}�[��Image�R���|�[�l���g

    // �^�C�}�[�̍X�V
    public void UpdateTimer(float remainingTime, float totalDuration)
    {
        // �c�莞�Ԃ̊������v�Z
        float fillAmount = remainingTime / totalDuration;

        // �^�C�}�[�̓h��Ԃ����X�V
        timerImage.fillAmount = fillAmount;
    }
}
