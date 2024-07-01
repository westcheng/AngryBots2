using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text fpsText;

    public float updateInterval = 0.2F;
    private double lastInterval;
    private int frames = 0;
    private float fps;
    
	float deltaTime;
	
	void Update ()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        SetFPS();
	}

	void SetFPS()
	{
		UnityEngine.Profiling.Profiler.BeginSample("Custom Update");
		
		++frames;
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval)
		{
			fps = (float)(frames / (timeNow - lastInterval));
			frames = 0;
			lastInterval = timeNow;
		}

		fpsText.text = string.Format("FPS: {0:00.}", fps);
		
		UnityEngine.Profiling.Profiler.EndSample();
	}
}