using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

    public class AudioManager : MonoBehaviour
    {
        public static AudioManager INSTANCE;

        private void Awake()
        {
            if (INSTANCE)
            {
                Destroy(this);
            }
            else
            {
                INSTANCE = this;
                DontDestroyOnLoad(this);
            }
        }

    private void Start()
    {
        foreach(var element in audioToPlay)
        {
            AudioSources.Add(element.Name, element.AudioClip);  
        }
    }

    public List<NameAudio> audioToPlay = new List<NameAudio>();

        [Serializable]
        public struct NameAudio
        {
            public string Name;
            public AudioClip AudioClip;
        }

        private Dictionary<string, AudioClip> AudioSources = new Dictionary<string, AudioClip>();

        public void PlaySound(string name, Vector3 postion)
        {
            if (AudioSources.ContainsKey(name))
            {
                GameObject obj = new GameObject(name);
                obj.transform.position = postion;
                AudioSource source = obj.AddComponent<AudioSource>();
                source.clip = AudioSources[name];
                source.Play();
                Destroy(obj, AudioSources[name].length + 1);
            }
        }
    }