/*********************************************
 *
 *   Title: Light特效
 *
 *   Description: 动态绑定,当开始旋转的时候,做一个渐隐渐现的效果
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

public class LightAnimate : MonoBehaviour
{
	bool isStare = false;
	Image lightImage;

	void Awake ()
	{
		lightImage = GetComponent<Image> ();
	}

	/// <summary>
	/// 开始动画
	/// </summary>
	public void StartAnimate ()
	{
		//初始值
		lightImage.color = new Color (lightImage.color.r, lightImage.color.g, lightImage.color.b, 1.0f);
	}

	void Update ()
	{
		if (lightImage.color.a <= 0.0f)
			return;
		float alpha = lightImage.color.a - 0.05f;
		//渐隐效果
		if (alpha <= 0)
			alpha = 0;
		lightImage.color = new Color (lightImage.color.r, lightImage.color.g, lightImage.color.b, alpha);
	}
}