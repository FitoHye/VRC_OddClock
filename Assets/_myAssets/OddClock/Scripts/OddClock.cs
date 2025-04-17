using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UIElements;
using VRC.SDKBase;
using VRC.Udon;

public class OddClock : UdonSharpBehaviour
{
    // private bool DEBUG_oddToggle = false;
    [Header("Clock Body")]
    [SerializeField] private Transform clockBody;

    [Header("Hands")]
    [SerializeField] private Transform hourHand;   // 1/120 degrees per second
    [SerializeField] private Transform minuteHand; // 0.1 degrees per second
    [SerializeField] private Transform secondHand; // 6 degrees per second
    [Header("Tick Sound")]
    [SerializeField] private GameObject SoundObject;
    [SerializeField] private AudioClip TickSound;
    private AudioSource audioSource;

    private float tickTimer = 0f;

    void Start()
    {
        if (SoundObject != null){
            if (audioSource != null && TickSound != null)
            {
                audioSource = SoundObject.GetComponent<AudioSource>();
                audioSource.clip = TickSound;
            }
            else
            {
                Debug.LogWarning("AudioSource or TickSound not properly assigned!");
            }
        }
        else
        {
            Debug.LogWarning("SoundObject is not assigned!");
        }
    }

    void Update()
    {
        tickTimer += Time.deltaTime;
        OddHands();
    }

    // private void UpdateHands()
    // {
    //     //시 분 초 구함.
    //     float nowHour = (float)DateTime.Now.Hour % 12;
    //     float nowMinute = DateTime.Now.Minute;
    //     float nowSecond = DateTime.Now.Second;

    //     // 각도 계산
    //     float secondAngle = nowSecond * 6f;
    //     float minuteAngle = nowMinute * 6f + secondAngle / 60;
    //     float hourAngle = nowHour * 30 + minuteAngle / 12;

    //     //대입
    //     CalculateRotationVector(hourHand, hourAngle);
    //     CalculateRotationVector(minuteHand, minuteAngle);
    //     CalculateRotationVector(secondHand, secondAngle);
    // }

    private void OddHands()
    {
        //뇌가 아픈
        float nowHour = (float)DateTime.Now.Hour % 12;
        float nowMinute = DateTime.Now.Minute;
        float nowSecond = DateTime.Now.Second;

        // 각도 계산
        float secondAngle = nowSecond * 6f;
        float minuteAngle = nowMinute * 6f + secondAngle / 60;
        float hourAngle = nowHour * 30 + minuteAngle / 12;

        // 소리 출력 TODO: 왜 고장났는지 찾고 이해할 것.
        // if (tickTimer >= 1f)
        // {
        //     tickSoundPlay();
        //     tickTimer = 0f;
        // }

        //각도 변경
        CalculateRotationVector(clockBody, 0-secondAngle);
        CalculateRotationVector(minuteHand, minuteAngle-secondAngle);
        CalculateRotationVector(hourHand, hourAngle-secondAngle);
    }

    private void CalculateRotationVector(Transform hand, float degree)
    {
        hand.localRotation = Quaternion.Euler(new Vector3(0f, 0f, degree));
    }

    private void tickSoundPlay()
    {
        if (SoundObject != null && TickSound != null)
        {
            audioSource.PlayOneShot(TickSound);
        }
    }
}