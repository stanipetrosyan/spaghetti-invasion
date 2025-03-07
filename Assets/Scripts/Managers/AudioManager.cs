using Port;
using UnityEngine;

namespace Managers {
    public class AudioManager: MonoBehaviour, IManager {
        [SerializeField] private AudioSource prisonAudio;
        
        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }

        private void Start() {
            prisonAudio.Play();
            Debug.Log("Playing prison audio");
        }
    }
}