using UnityEngine;
using System.Collections;
 
public class TimerScript : MonoBehaviour 
{
	// Static Instance of this Timer (since you seem to want a single Timer)
	public static TimerScript m_instance;
	 
    public float m_startTime; // sets how much time the player has to start with
	public float m_timePassed;
	 
	public float RemainingSeconds;
 
    public bool IsTicking;
    public bool m_stopTimer;

 
    // Use this for initialization
    public void StartTimer () 
    {
		m_stopTimer = false;

		// Another timer exists, kill this one
		if(m_instance != null && m_instance != this)
		{
			Destroy(this);
		}
		else
		{
			// assign Singleton
			m_instance = this;
		}
		
		// Init Timer
		m_startTime = 0f;
		m_timePassed = 0f;
		
		RemainingSeconds = m_startTime;
		
		IsTicking = true;
    }

    //Update is called once per frame
    void Update () 
    {
		
        if (IsTicking) // already a bool no check for true needed
        {
			// add frame time to passed time
			m_timePassed += Time.deltaTime;
			
			RemainingSeconds = m_startTime - m_timePassed;
		
			// Clamp time to start time
			if (RemainingSeconds >= m_startTime)
            {
				RemainingSeconds = m_startTime;
            } 
			
			// No time left
			if(RemainingSeconds <= 0)
			{
				// This is Game Over
				RemainingSeconds = 0;
				m_stopTimer = true;
				return;
			}
        }
    }
	
	// Use this Method to access your timer
	public static TimerScript Get()
	{
		// failsafe
		if(m_instance = null)
		{
			GameObject go = new GameObject();
			m_instance = go.AddComponent<TimerScript>();
		}
		return m_instance;
	}
	
	// Reset your time
	public void ResetTimer()
	{
		m_timePassed = 0;
	}
	
	// If you want to substract time, use a negative value
	public void AddTime(float _seconds)
	{
		m_timePassed -= _seconds;
	}
 }