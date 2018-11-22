using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoSingleton<Repeater>
{
    public class RepeatInfo
    {
        public int repeatId;
        public float startTime;
        public float timeInterval;
        public int repeatTimes;
        public Action onRepeat;
        public Action onStop;
        public float curTime;
        public bool hasStart;
        public bool hasStop;
    }

    private int repeatId = 1;
    private List<RepeatInfo> repeats = new List<RepeatInfo>();
    private List<RepeatInfo> removeList = new List<RepeatInfo>();

    public int StartRepeat(float startTime, float timeInterval, int repeatTimes, Action onRepeat, Action onStop)
    {
        RepeatInfo repeat = new RepeatInfo()
        {
            repeatId = repeatId,
            startTime = startTime,
            timeInterval = timeInterval,
            repeatTimes = repeatTimes,
            onRepeat = onRepeat,
            onStop = onStop,
            curTime = 0,
            hasStart = false,
            hasStop = false,
        };
        repeatId++;
        repeats.Add(repeat);
        return repeatId;
    }

    public int RepeatOnce(float startTime, Action onStop)
    {
        return StartRepeat(startTime, 0f, 1, null, onStop);
    }

    public int RepeatForever(float startTime, float timeInterval, Action onRepeat)
    {
        return StartRepeat(startTime, timeInterval, -1, onRepeat, null);
    }

    public void StopRepeat(int repId)
    {
        for (int i = 0; i < repeats.Count; i++)
        {
            var rep = repeats[i];
            if (rep.repeatId == repId)
            {
                rep.hasStop = true;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < repeats.Count; i++)
        {
            var rep = repeats[i];
            CheckStartTime(rep);
            CheckRepeatInterval(rep);
            CheckRepeatTimes(rep);
            CheckStopedRepeat(rep);
        }
		for(int i = 0; i < removeList.Count; i++)
		{
			repeats.Remove(removeList[i]);
		}
		removeList.Clear();
    }

    private void CheckStartTime(RepeatInfo rep)
    {
        if (!rep.hasStart)
        {
            rep.curTime += Time.deltaTime;
            if (rep.curTime > rep.startTime)
            {
                rep.hasStart = true;
                rep.curTime = 0f;
            }
        }
    }

    private void CheckRepeatInterval(RepeatInfo rep)
    {
        if (rep.hasStart && !rep.hasStop)
        {
            rep.curTime += Time.deltaTime;
            if (rep.curTime > rep.timeInterval)
            {
                if (rep.onRepeat != null)
                {
                    rep.onRepeat();
                }
                rep.curTime = 0f;
                rep.repeatTimes--;
            }
        }
    }

    private void CheckRepeatTimes(RepeatInfo rep)
    {
        if (rep.hasStart && !rep.hasStop)
        {
            if (rep.repeatTimes == 0)
            {
                if (rep.onStop != null)
                {
                    rep.onStop();
                }
                rep.hasStop = true;
            }
        }
    }

    private void CheckStopedRepeat(RepeatInfo rep)
    {
        if (rep.hasStop)
        {
            removeList.Add(rep);
        }
    }
}
