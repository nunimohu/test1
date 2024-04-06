﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounselorDoorScript : MonoBehaviour
{
	public CounselorScript Counselor;
	public PromptScript Prompt;
	public UISprite Darkness;

	public bool FadeOut;
	public bool FadeIn;
	public bool Exit;

	void Start()
	{
		//Anti-Osana Code
		#if !UNITY_EDITOR
		Prompt.enabled = false;
		Prompt.Hide();
		#endif

		//enabled = false;
	}

	void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0.0f)
		{
			Prompt.Circle[0].fillAmount = 1.0f;

            bool DoNotProceed = false;

            for (int ID = 1; ID < Counselor.StudentManager.Students.Length; ID++)
            {
                StudentScript student = Counselor.StudentManager.Students[ID];

                if (student != null)
                {
                    if (student.Hunting)
                    {
                        Prompt.Yandere.NotificationManager.CustomText = "A murder is taking place!";
                        Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);

                        DoNotProceed = true;
                    }
                }
            }

            if (!DoNotProceed && !Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0 && !FadeIn &&
				Prompt.Yandere.Bloodiness == 0 && Prompt.Yandere.Sanity > 66.66666f &&
				!Prompt.Yandere.Carrying && !Prompt.Yandere.Dragging)
			{
				if (!Counselor.Busy)
				{
					Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.IdleAnim);
					Prompt.Yandere.Police.Darkness.enabled = true;
					Prompt.Yandere.CanMove = false;
					FadeOut = true;
				}
				else
				{
					Counselor.CounselorSubtitle.text = Counselor.CounselorBusyText;
					Counselor.MyAudio.clip = Counselor.CounselorBusyClip;
					Counselor.MyAudio.Play();
				}
			}
		}

		if (FadeOut)
		{
			float Alpha = Mathf.MoveTowards(Darkness.color.a, 1, Time.deltaTime);
			Darkness.color = new Color(0, 0, 0, Alpha);

			if (Darkness.color.a == 1)
			{
				if (!Exit)
				{
					Prompt.Yandere.CharacterAnimation.Play("f02_sit_00");
					Prompt.Yandere.transform.position = new Vector3(-27.51f, 0, 12);
					Prompt.Yandere.transform.localEulerAngles = new Vector3(0, -90, 0);

					Counselor.Talk();
					FadeOut = false;
					FadeIn = true;
				}
				else
				{
					Darkness.color = new Color(0, 0, 0, 2);

					Counselor.Quit();
					FadeOut = false;
					FadeIn = true;
					Exit = false;
				}
			}
		}

		if (FadeIn)
		{
			float Alpha = Mathf.MoveTowards(Darkness.color.a, 0, Time.deltaTime);
			Darkness.color = new Color(0, 0, 0, Alpha);

			if (Darkness.color.a == 0)
			{
				FadeIn = false;
			}
		}
	}
}