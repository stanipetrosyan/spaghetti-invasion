using Port;
using UnityEngine;

namespace Managers {
    public class AudioManager: MonoBehaviour, IManager {
        [SerializeField] private AudioSource prisonAudio;
        [SerializeField] private AudioSource heartBeatAudio;
        [SerializeField] private AudioSource deathAudio;
        [SerializeField] private AudioSource controlRoomAudio;
        
        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }

        private void Start() {
            PlayPrisonAudio();
        }

        public void StopAll() {
            prisonAudio.Stop();
            heartBeatAudio.Stop();
            deathAudio.Stop();
            controlRoomAudio.Stop();
        }
        
        public void PlayPrisonAudio() {
            if(prisonAudio.isPlaying) return;
            
            prisonAudio.Play();
        }
        
        public void PlayControlRoomAudio() {
            if(controlRoomAudio.isPlaying) return;
            
            controlRoomAudio.Play();
        }


        public void StopPrisonAudio() {
            prisonAudio.Stop();
        }

        public void PlayHeartBeat() {
            if(heartBeatAudio.isPlaying) return;
            
            heartBeatAudio.Play();
        }
        
        public void PlayDeath() {
            if(deathAudio.isPlaying) return;
            
            deathAudio.Play();
        }
        
        
        public void StopHeartBeat() {
            heartBeatAudio.Stop();
        }
        public void StopDeath() {
            deathAudio.Stop();
        }
    }
}