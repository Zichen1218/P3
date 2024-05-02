using UnityEngine;
using System.Collections;

public class TreasureInteraction : MonoBehaviour
{
    public Transform boxLid;       // 宝箱盖子的 Transform
    public Transform textObject;   // 文本对象的 Transform
    public Transform player;       // 玩家的 Transform，直接从 Inspector 指定
    private bool isOpened = false; // 状态标记，防止重复动画

    void OnTriggerEnter(Collider other)
    {
        // 检查触发碰撞的对象是否是指定的玩家
        if (other.transform == player && !isOpened)
        {
            isOpened = true;
            StartCoroutine(OpenTreasureBox());
        }
    }

    IEnumerator OpenTreasureBox()
    {
        float duration = 1.0f; // 动画持续时间，1秒
        float elapsed = 0.0f;  // 已经过去的时间

        Vector3 startLidRotation = boxLid.localEulerAngles;
        Vector3 endLidRotation = new Vector3(startLidRotation.x - 30, startLidRotation.y, startLidRotation.z);

        Vector3 startLidPosition = boxLid.localPosition;
        Vector3 endLidPosition = new Vector3(startLidPosition.x, startLidPosition.y + 0.35f, startLidPosition.z+0.2f);

        Vector3 startTextPosition = textObject.localPosition;
        Vector3 endTextPosition = new Vector3(startTextPosition.x, startTextPosition.y + 4, startTextPosition.z);

        while (elapsed < duration)
        {
            // 计算当前动画的进度
            float progress = elapsed / duration;

            // 使用线性插值计算当前的旋转和位置
            boxLid.localEulerAngles = Vector3.Lerp(startLidRotation, endLidRotation, progress);
            boxLid.localPosition = Vector3.Lerp(startLidPosition, endLidPosition, progress);
            textObject.localPosition = Vector3.Lerp(startTextPosition, endTextPosition, progress);

            // 增加已过去的时间
            elapsed += Time.deltaTime;
            // 等待下一帧
            yield return null;
        }

        // 确保动画完成时，物体属性完全等于目标值
        boxLid.localEulerAngles = endLidRotation;
        boxLid.localPosition = endLidPosition;
        textObject.localPosition = endTextPosition;
    }
}
