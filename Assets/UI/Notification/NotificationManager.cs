using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FixedSizedGameObjectQueue
{
    Queue<GameObject> q = new Queue<GameObject>();

    public int Limit { get; set; }
    public void Enqueue(GameObject obj)
    {
        q.Enqueue(obj);
        lock (this)
        {
            GameObject overflow;
            while (q.Count > Limit)
            {
                overflow = q.Dequeue();
                GameObject.Destroy(overflow);
            }
        }
    }
}

public class NotificationManager : MonoBehaviour 
{
    [SerializeField]
    private RectTransform notificationCanvasRect;
    [SerializeField]
    private Transform containerRect;

    [SerializeField]
    private GameObject notificationPrefab;

    [SerializeField]
    private int maxMessageCount;

    float height;

    FixedSizedGameObjectQueue queue;

    private static NotificationManager _instance;

    public static NotificationManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<NotificationManager>();
            return _instance;
        }
    }

    void Start()
    {
        queue = new FixedSizedGameObjectQueue();
        queue.Limit = maxMessageCount;
    }

    public void popUpError(string message)
    {
        GameObject obj = (GameObject)Instantiate(notificationPrefab);
        obj.transform.SetParent(containerRect);

        obj.GetComponent<Notification>().init(notificationCanvasRect.localScale.x, message);
        Debug.Log("[NOTIFICATION MANAGER]" + message);

        queue.Enqueue(obj);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            NotificationManager.Instance.popUpError("pouet");
    }
}
