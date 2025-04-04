using Port;
using UnityEngine;

namespace Managers {
    public class AudioManager: MonoBehaviour, IManager {
        [SerializeField] private AudioSource prisonAudio;
        [SerializeField] private AudioSource heartBeatAudio;
        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }

        private void Start() {
            //prisonAudio.Play();
        }

        public void PlayHeartBeat() {
            if(heartBeatAudio.isPlaying) return;
            
            heartBeatAudio.Play();
        }
        
        
        public void StopHeartBeat() {
            heartBeatAudio.Stop();
        }
    }
}