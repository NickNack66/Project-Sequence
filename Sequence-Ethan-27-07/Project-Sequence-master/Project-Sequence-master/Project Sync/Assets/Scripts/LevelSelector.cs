using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader Fader;

    public void Select (int levelName)
    {
        Fader.FadeTo(levelName);
    }
}
