using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwing : MonoBehaviour
{
    public Transform armBase;   // 胳膊基座的Transform，arm将围绕此旋转
    public float swingSpeed = 1.0f;  // 挥舞的速度
    public float swingAmplitude = 30.0f; // 挥舞的最大幅度（角度）

    void Update()
    {
        // 计算当前的挥舞角度，使用 Mathf.Abs 确保角度总是正值
        float angle = Mathf.Sin(Time.time * swingSpeed*10) * swingAmplitude*0.005f;
        Vector3 rotationAxis = Vector3.forward;
        //Vector3 pivotPoint = transform.TransformPoint(armBase.position);

        // 设置胳膊的旋转
        transform.RotateAround(armBase.position,rotationAxis,angle);
    }
}