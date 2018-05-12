using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	public float gameMinutesPerSecond = 1;
	public Material nightSkybox;
	public Material daySkybox;

	private float anglePerSecond;
	private bool isNight = false;

	private void Start()
	{
		float anglePerGameMinute = 360f / (60f * 24f);
		anglePerSecond = anglePerGameMinute * gameMinutesPerSecond;
	}

	void Update ()
	{
		float angle = anglePerSecond * Time.deltaTime;
		transform.RotateAround(transform.position, Vector3.forward, angle);

		if (ShouldChangeSkybox())
		{
			isNight = !isNight;
			ChangeSkybox();
		}
	}

	private bool ShouldChangeSkybox()
	{
		bool isCurrenltyNight = transform.rotation.eulerAngles.x > 270 
								&& transform.rotation.eulerAngles.x < 330;
		return isNight != isCurrenltyNight;
	}

	void ChangeSkybox()
	{
		RenderSettings.skybox = isNight ? nightSkybox : daySkybox;
	}
}
