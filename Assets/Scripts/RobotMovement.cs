using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed = 5.0f;       // 移动速度
    private float startZ = 1.0f;     // 开始的 z 坐标
    private float endZ = 9.5f;       // 结束的 z 坐标
    private float rangeZ;            // 移动范围

    void Start()
    {
        rangeZ = endZ - startZ;      // 计算移动范围
    }

    void Update()
    {
        // 使用 Mathf.PingPong 计算 z 坐标的当前位置
        float zPosition = startZ + Mathf.PingPong(Time.time * speed, rangeZ);

        // 更新机器人的位置
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
    }
}
