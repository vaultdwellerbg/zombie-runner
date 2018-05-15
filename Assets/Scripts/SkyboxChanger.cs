using UnityEngine;

namespace Assets.Scripts
{
	public class SkyboxChanger
	{
		private Material daySkybox, nightSkybox;
		private float startOfStarsFadeIn;
		private float startOfStarsFadeOut;

		public SkyboxChanger(Material daySkybox, Material nightSkybox)
		{
			this.daySkybox = daySkybox;
			this.nightSkybox = nightSkybox;
		}

		public void StartStarsFadeIn()
		{
			startOfStarsFadeIn = Time.time;
		}

		public bool StarsFadeOutStarted()
		{
			return startOfStarsFadeOut > 0f;
		}

		public void StartStarsFadeOut()
		{
			startOfStarsFadeOut = Time.time;
		}

		public void ResetFadeTimers()
		{
			startOfStarsFadeIn = 0f;
			startOfStarsFadeOut = 0f;
		}

		public void ChangeSkybox(bool isNight)
		{
			RenderSettings.skybox = isNight ? nightSkybox : daySkybox;
		}

		public void Update()
		{
			if (ShouldFadeInStars())
			{
				FadeInStars();
			}

			if (ShouldFadeOutStars())
			{
				FadeOutStars();
			}
		}

		private bool ShouldFadeInStars()
		{
			return nightSkybox.GetFloat("_Exposure") < 1 && startOfStarsFadeIn > 0f;
		}

		private void FadeInStars()
		{
			nightSkybox.SetFloat("_Exposure", Mathf.Clamp(Time.time - startOfStarsFadeIn, 0f, 1f));
		}

		private bool ShouldFadeOutStars()
		{
			return nightSkybox.GetFloat("_Exposure") > 0 && startOfStarsFadeOut > 0f;
		}

		private void FadeOutStars()
		{
			nightSkybox.SetFloat("_Exposure", 1f - Mathf.Clamp(Time.time - startOfStarsFadeOut, 0f, 1f));
		}
	}
}
