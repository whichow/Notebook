using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoSingleton<Updater>
{
    public class UpdateInfo
    {
        public int updateId;
        public int interval;
        public int updateCount;
        public Action onUpdate;
    }

    private List<UpdateInfo> updates = new List<UpdateInfo>();
    private List<UpdateInfo> fixedUpdates = new List<UpdateInfo>();
    private List<UpdateInfo> updateRemoveList = new List<UpdateInfo>();
    private List<UpdateInfo> fixedUpdateRemoveList = new List<UpdateInfo>();
    private int updateId = 1;

    public float FixedTimeStep
    {
        get
        {
            return Time.fixedDeltaTime;
        }
        set
        {
            Time.fixedDeltaTime = value;
        }
    }

    public int StartUpdate(int interval, Action onUpdate)
    {
        UpdateInfo update = new UpdateInfo()
        {
            updateId = updateId,
            interval = interval,
            onUpdate = onUpdate,
            updateCount = 0,
        };
        updateId++;
        updates.Add(update);
        return updateId;
    }

    public int StartFixedUpdate(int interval, Action onUpdate)
    {
        UpdateInfo update = new UpdateInfo()
        {
            updateId = updateId,
            interval = interval,
            onUpdate = onUpdate,
            updateCount = 0,
        };
        updateId++;
        fixedUpdates.Add(update);
        return updateId;
    }

    public void StopUpdate(int updateId)
    {
        for (int i = 0; i < updates.Count; i++)
        {
            var update = updates[i];
            if (update.updateId == updateId)
            {
                updateRemoveList.Add(update);
            }
        }
    }

    public void StopFixedUpdate(int updateId)
    {
        for (int i = 0; i < fixedUpdates.Count; i++)
        {
            var update = fixedUpdates[i];
            if (update.updateId == updateId)
            {
                fixedUpdateRemoveList.Add(update);
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < updates.Count; i++)
        {
            var update = updates[i];
            if (update.updateCount % update.interval == 0)
            {
                if (update.onUpdate != null)
                {
                    update.onUpdate();
                }
            }
        }
        for (int i = 0; i < updateRemoveList.Count; i++)
        {
            updates.Remove(updateRemoveList[i]);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < fixedUpdates.Count; i++)
        {
            var update = fixedUpdates[i];
            if (update.updateCount % update.interval == 0)
            {
                if (update.onUpdate != null)
                {
                    update.onUpdate();
                }
            }
        }
        for (int i = 0; i < fixedUpdateRemoveList.Count; i++)
        {
            updates.Remove(fixedUpdateRemoveList[i]);
        }
    }
}
