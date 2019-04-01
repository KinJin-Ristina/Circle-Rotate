/*********************************************
 *
 *   Title: 大转盘的实现
 *
 *   Description: 通过转盘的数量,来计算需要旋转到的角度.我这里是有 12个 旋转的位置, 故 360/12 = 30
 *                所以,以30度为一个单位,进行偏移计算
 *
 *   Author: 自律
 *
 *   Date: 2019.4.1
 *
 *   Modify: 
 * 
 *********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DrawRotateScr : MonoBehaviour
{
    /// <summary>
    /// Arrow图片
    /// </summary>
    Image arrowImg;
    /// <summary>
    /// 开始按钮
    /// </summary>
    Button drawBtn;
    /// <summary>
    /// Light父物体
    /// </summary>
    Transform lightCircle;
    /// <summary>
    /// 停留的坐标激活组件 从而达到渐隐渐现的效果
    /// </summary>
    Transform lightIndex;
    /// <summary>
    /// 是否开始旋转
    /// </summary>
    bool isStart = false;
    /// <summary>
    /// 箭头欧拉角
    /// </summary>
    float angle;
    /// <summary>
    /// 旋转角度 30° - 330°
    /// </summary>
    float rotateAngle;
    /// <summary>
    /// 最后的偏移的角度
    /// </summary>
    float lastAngle;

    void Start()
    {
        //获取组件
        arrowImg = transform.Find("Arrow").GetComponent<Image>();
        drawBtn = transform.Find("DrawBtn").GetComponent<Button>();
        lightCircle = transform.Find("LightCircle");
        drawBtn.onClick.RemoveAllListeners();
        //绑定事件
        drawBtn.onClick.AddListener(OnTest);
    }

    void OnTest()
    {
        float curRotateAngle = 0f;
        curRotateAngle = SetRotateAngle(150);
        StartRotate(curRotateAngle);
    }


    void Update()
    {
        if (!isStart)
        {
            return;
        }
        //设置欧拉角
        angle = arrowImg.transform.localEulerAngles.z;
        //设置旋转角
        rotateAngle = (int)((angle + 15) / 30) * 30;
        //激活动画组件
        lightIndex = lightCircle.Find("Light" + rotateAngle);
        //如果到达了该目标
        if (lightIndex)
        {
            //设置激活
            lightIndex.gameObject.SetActive(true);
            //如果没有获取到这个组件,就添加
            if (!lightIndex.GetComponent<LightAnimate>())
            {
                lightIndex.gameObject.AddComponent<LightAnimate>();
            }
            //开启动画
            lightIndex.GetComponent<LightAnimate>().StartAnimate();
        }
    }
    /// <summary>
    /// 开始旋转
    /// </summary>
    /// <param name="_rotateAngle">传入的旋转角度.</param>
    void StartRotate(float _rotateAngle)
    {
        if (isStart)
        {
            return;
        }
        isStart = true;
        float rotateTemp = _rotateAngle;
        //获取 设置偏移的 特效 点亮
        //持续时间
        float duration = 4.0f;
        //重复的旋转次数
        int repeatCount = 4;
        //DoTween 旋转 顺时针旋转
        Tween tweenRotate = arrowImg.transform.DORotate(new Vector3(0, 0, -(rotateTemp + 360 * repeatCount)), duration, RotateMode.FastBeyond360);
        //重置时间
        Invoke("RotateComplete", 6f);
    }

    /// <summary>
    /// 旋转完成重置
    /// </summary>
    void RotateComplete()
    {
        isStart = false;
        Tween tweenReset = arrowImg.transform.DORotate(new Vector3(0, 0, 0), .4f, RotateMode.FastBeyond360);
    }
    /// <summary>
    /// 设置偏转角所要停留的位置
    /// </summary>
    /// <returns>The rotate angle.</returns>
    /// <param name="value">Value.</param>
	float SetRotateAngle(int value)
    {
        float rotateAngle = .0f;
        switch (value)
        {
            case 0:
                {
                    rotateAngle = 0.0f;
                }
                break;
            case 330:
                {
                    rotateAngle = 330.0f;
                }
                break;
            case 300:
                {
                    rotateAngle = 300.0f;
                }
                break;
            case 270:
                {
                    rotateAngle = 270.0f;
                }
                break;
            case 240:
                {
                    rotateAngle = 240.0f;
                }
                break;
            case 210:
                {
                    rotateAngle = 210.0f;
                }
                break;
            case 180:
                {
                    rotateAngle = 180.0f;
                }
                break;
            case 150:
                {
                    rotateAngle = 150.0f;
                }
                break;
            case 120:
                {
                    rotateAngle = 120.0f;
                }
                break;
            case 90:
                {
                    rotateAngle = 90.0f;
                }
                break;
            case 60:
                {
                    rotateAngle = 60.0f;
                }
                break;
            case 30:
                {
                    rotateAngle = 30.0f;
                }
                break;
            default:
                break;
        }
        return rotateAngle;
    }
}