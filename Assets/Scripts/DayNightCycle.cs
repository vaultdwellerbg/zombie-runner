using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	public float gameMinutesPerSecond = 1;
	public Material nightSkybox;
	public Material daySkybox;

	private float anglePerSecond;
	private bool isNight = false;
	private float startOfStarFadeIn;
	private float startOfStarFadeOut;
	private float totalAngle;

	private void Start()
	{
		float anglePerGameMinute = 360f / (60f * 24f);
		anglePerSecond = anglePerGameMinute * gameMinutesPerSecond;
		nightSkybox.SetFloat("_Exposure", 0f);
	}

	void Update ()
	{
		// rotation
		float angle = anglePerSecond * Time.deltaTime;
		transform.RotateAround(transform.position, Vector3.forward, angle);

		// total angle tracking
		totalAngle += angle;
		if (totalAngle > 360f)
		{
			totalAngle -= 360f;
		}

		// skybox change
		if (ShouldChangeSkybox())
		{
			isNight = !isNight;
			ChangeSkybox();
			if (isNight)
			{
				startOfStarFadeIn = Time.time;
			}
			else
			{
				startOfStarFadeIn = 0f;
				startOfStarFadeOut = 0f;
			}
		}

		if (nightSkybox.GetFloat("_Exposure") < 1 && startOfStarFadeIn > 0f)
		{
			nightSkybox.SetFloat("_Exposure", Mathf.Clamp(Time.time - startOfStarFadeIn, 0f, 1f));
		}

		if (startOfStarFadeOut == 0f && totalAngle > 140f)
		{
			startOfStarFadeOut = Time.time;
		}

		if (nightSkybox.GetFloat("_Exposure") > 0 && startOfStarFadeOut > 0f)
		{
			nightSkybox.SetFloat("_Exposure", 1f - Mathf.Clamp(Time.time - startOfStarFadeOut, 0f, 1f));
		}

	}

	private bool ShouldChangeSkybox()
	{
		bool isCurrenltyNight = totalAngle > 30f 
								&& totalAngle < 150f;
		return isNight != isCurrenltyNight;
	}

	void ChangeSkybox()
	{
		RenderSettings.skybox = isNight ? nightSkybox : daySkybox;
	}
}
