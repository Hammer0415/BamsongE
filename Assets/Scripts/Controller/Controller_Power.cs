using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Power : MonoBehaviour
{
    // public
    public float fPowerValue = 1.0f;        // 파워 변수

    [Range(1.0f, 20.0f)]
    public float fPowerChangeSpeed = 3.0f;  // 파워 변경 스피드

    public Slider sPowerSlider;             // 파워 슬라이드
    public bool bIsClick = false;           // 밤송이 제너레이터

    // private
    private bool bCheckPower = false;       // 파워값 확인 변수

    private void PowerUpDown()
    {
        // 마우스를 클릭했을 시
        if (bIsClick == true)
        {
            // 파워값 올리고 내리기
            if (bCheckPower == false)
            {
                fPowerValue += fPowerChangeSpeed * Time.deltaTime;      // 파워 올리기
            }
            else
            {
                fPowerValue -= fPowerChangeSpeed * Time.deltaTime;      // 파워 내리기
            }

            // 파워값 확인
            if (fPowerValue <= 1.0f)
            {
                bCheckPower = false;
            }
            if (fPowerValue >= 10.0f)
            {
                bCheckPower = true;
            }

            fPowerValue = Mathf.Clamp(fPowerValue, 1.0f, 10.0f);     // 파워 값 제한

            sPowerSlider.value = fPowerValue;       // 슬라이더 값 변경
        }
    }

    void Update()
    {
        PowerUpDown();
    }
}
