using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class Sound
    {
        //Sử dụng enum thay vì string;
        public GameEnum.ESound tag;
        public GameObject prefab;
        public int size;
    }
    public List<Sound> sounds;

    public Dictionary<string, Queue<GameObject>> soundsDictionary;

    [System.Serializable]
    public class Music
    {
        public GameEnum.EMusic tag;
        public GameObject prefab;
        public int size = 1;
    }
    public List<Music> musics;

    public Dictionary<string, Queue<GameObject>> musicsDictionary;

    void Start()
    {
        soundsDictionary = new Dictionary<string, Queue<GameObject>>();
        musicsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Sound pool in sounds)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                //Đảm bảo sound được thêm vào sound Manager không bị hủy khi load sceneS
                DontDestroyOnLoad(obj);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }
            soundsDictionary.Add(pool.tag.ToString(), objectsPool);
        }

        foreach (Music pool in musics)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                //Đảm bảo music được thêm vào sound Manager không bị hủy khi load sceneS
                DontDestroyOnLoad(obj);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }
            musicsDictionary.Add(pool.tag.ToString(), objectsPool);
        }
        PlayIndexMusic();
    }

    public GameObject PlaySound(GameEnum.ESound eTag)
    {
        string tag = eTag.ToString();
        if (!soundsDictionary.ContainsKey(tag))
        {
            Debug.Log("Key " + tag + " doesn't exist!!!");
            return null;
        }

        GameObject objToSpawn = soundsDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);

        soundsDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

    public GameObject PlayMusic(GameEnum.EMusic eTag)
    {
        string tag = eTag.ToString();
        if (!musicsDictionary.ContainsKey(tag))
        {
            Debug.Log("Key " + tag + " doesn't exist!!!");
            return null;
        }

        StopAllMusic();

        GameObject objToSpawn = musicsDictionary[tag].Dequeue();
        objToSpawn.SetActive(true);

        musicsDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

    public void StopAllMusic()
    {
        foreach (var queue in musicsDictionary.Values)
        {
            foreach (var obj in queue)
            {
                obj.SetActive(false);
            }
        }
    }

    public void PlayIndexMusic()
    {
        PlayMusic(GameEnum.EMusic.MusicIndex);
    }
}
