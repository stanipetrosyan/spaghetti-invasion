using Managers;
using UnityEngine;

namespace Port{
    public interface IManager{
        ManagerStatus Status { get; set; }
        
        void Startup();
    }
}