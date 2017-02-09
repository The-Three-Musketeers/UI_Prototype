using UnityEngine;
using UnityEngine.SceneManagement;

//This script handles screen changes dynamically. It was based heavily off of code found
//on the topic in one of Unity's officical tutorials.

public class ScreenChanges : MonoBehaviour
{

    public Texture2D fadeOutTexture;
    public AudioSource audio;
    public AudioSource music;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void Start()
    {
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        DontDestroyOnLoad(audio);
        DontDestroyOnLoad(music);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        BeginFade(-1);
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }


    //Go to the next scene
    public void NextScene()
    {
        audio.Play();
        float fadeTime = BeginFade(1);
        System.Threading.Thread.Sleep(Mathf.CeilToInt(fadeTime));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Manual_Click.reset();
        changeMusic();
    }

    //Go to the last scene
    public void LastScene()
    {
        audio.Play();
        float fadeTime = BeginFade(1);
        System.Threading.Thread.Sleep(Mathf.CeilToInt(fadeTime));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); ;
        changeMusic();
    }

    //Go to a specific scene by name
    public void SpecificScene(string name)
    {
        audio.Play();
        float fadeTime = BeginFade(1);
        System.Threading.Thread.Sleep(Mathf.CeilToInt(fadeTime));
        SceneManager.LoadScene(name);
        changeMusic();
    }

    //Change Music when you get to the gameplay
    private void changeMusic()
    {
        if (SceneManager.GetActiveScene().name == "SelectRocketScreen")
        {
            Destroy(music);
            music = GameObject.Find("Music").GetComponent<AudioSource>();
            music.Play();
        }
    }
}
