
// using System;
// using UdonSharp;
// using Unity.Mathematics;
// using UnityEngine;
// using VRC.SDKBase;
// using VRC.Udon;

// public class graph2sharp : UdonSharpBehaviour
// {
//     private Vector3 angleVec3;
//     public Transform hour;
//     public Transform minute;
//     public Transform second;
//     private float angle;
//     void Start()
//     {
        
//     }
//     void Update() //예 : 13시 25분 45초
//     {
//         angle = (float)DateTime.Now.Second * 6; //270
//         angleVec3.z = angle; //(? ? 270f)
//         SetTransform(second);

//         angle = ((float)DateTime.Now.Minute * 6) + (angle / 60); // 현재 분만을 기준으로 하는 각도 + 이전 초 로 인한 추가 움직임.
//         angleVec3.z = angle;
//         SetTransform(minute);

//         angle = ((float)DateTime.Now.Hour * 30) + (angle / 12);
//         angleVec3.z = angle;
//         SetTransform(hour);
//     }
//     private void SetTransform(Transform target)
//     {
//         target.localRotation = Quaternion.Euler(angleVec3);
//     }
// }

using System;
using UdonSharp;
using Unity.Mathematics;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class graph2sharp : UdonSharpBehaviour
{
    private Vector3 angleVec3;
    public Transform hour;
    public Transform minute;
    public Transform second;
    private float angle;
    void Start()
    {
        
    }
    void Update() //예 : 13시 25분 45초
    {
        angle = (float)DateTime.Now.Second * 6; //270
        angleVec3.z = angle; //(? ? 270f)
        SetTransform(second);

        angle = ((float)DateTime.Now.Minute * 6) + (angle / 60); // 현재 분만을 기준으로 하는 각도 + 이전 초 로 인한 추가 움직임.
        angleVec3.z = angle;
        SetTransform(minute);

        angle = ((float)DateTime.Now.Hour * 30) + (angle / 12);
        angleVec3.z = angle;
        SetTransform(hour);
    }
    private void SetTransform(Transform target)
    {
        target.localRotation = Quaternion.Euler(angleVec3);
    }
}
