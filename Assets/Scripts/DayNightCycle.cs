using UnityEngine;
using Assets.Scripts;

public class DayNightCycle : MonoBehaviour {

	public float gameMinutesPerSecond = 1;
	public Material nightSkybox;
	public Material daySkybox;

	private float anglePerSecond;
	private bool isNight = false;
	private float totalAngle;
	private SkyboxChanger skyboxChanger;

	private void Start()
	{
		float anglePerGameMinute = 360f / (60f * 24f);
		anglePerSecond = anglePerGameMinute * gameMinutesPerSecond;
		nightSkybox.SetFloat("_Exposure", 0f);
		skyboxChanger = new SkyboxChanger(daySkybox, nightSkybox);
	}

	void Update ()
	{
		float anglePerFrame = anglePerSecond * Time.deltaTime;
		transform.RotateAround(transform.position, Vector3.forward, anglePerFrame);
		UpdateTotalAngle(anglePerFrame);

		if (ShouldChangeDayPeriod())
		{
			ChangeDayPeriod();
		}

		if (!skyboxChanger.StarsFadeOutStarted() && DayPeriodIsNear())
		{
			skyboxChanger.StartStarsFadeOut();
		}

		skyboxChanger.Update();
	}

	private void UpdateTotalAngle(float value)
	{
		totalAngle += value;
		if (totalAngle > 360f)
		{
			totalAngle -= 360f;
		}
	}

	private bool ShouldChangeDayPeriod()
	{
		bool isCurrenltyNight = totalAngle > 20f
								&& totalAngle < 150f;
		return isNight != isCurrenltyNight;
	}

	private void ChangeDayPeriod()
	{
		isNight = !isNight;
		skyboxChanger.ChangeSkybox(isNight);
		if (isNight)
		{
			skyboxChanger.StartStarsFadeIn();
		}
		else
		{
			skyboxChanger.ResetFadeTimers();
		}
	}

	private bool DayPeriodIsNear()
	{
		return totalAngle > 140f;
	}
}
