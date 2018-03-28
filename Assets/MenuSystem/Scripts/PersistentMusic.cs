using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusic : MonoBehaviour {

	public AudioClip[] audioClips;
	
	private AudioSource music;

	void Awake() 
	{
		GameObject.DontDestroyOnLoad(gameObject);
		music = GetComponent<AudioSource>();
		SetVolume(PlayerPrefsManager.GetMasterVolume());
		PlayClip(0);			
	}
	
	void PlayClip(int index)
	{
		music.Stop();
		music.clip = audioClips[index];		
		music.Play();		
	}

	void OnLevelFinishedLoading(Scene scene)
	{
		int level = scene.buildIndex;

		if (audioClips[level])
		{
			PlayClip(level);
		}
	}

	public void SetVolume(float volume)
	{
		music.volume = volume;
	}	
}
