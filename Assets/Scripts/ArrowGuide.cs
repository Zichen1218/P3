using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGuide : MonoBehaviour
{
    public Transform character;  // 角色的Transform
    public Transform treasure;   // 宝藏的Transform

    void Update()
    {
        // 设置箭头的位置为角色的位置，但是y坐标增加8
        transform.position = new Vector3(character.position.x, character.position.y + 8, character.position.z);

        // 箭头始终朝向宝藏
        transform.LookAt(treasure);
        transform.Rotate(180f, 0f, 0f);
    }
}
