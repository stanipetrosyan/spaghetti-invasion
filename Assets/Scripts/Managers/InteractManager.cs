using System.Collections;
using System.Collections.Generic;
using Managers;
using Port;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class InteractManager : MonoBehaviour, IManager{
    [SerializeField] private TextMeshProUGUI text;

    public void Activate() {
        text.gameObject.SetActive(true);
    }

    public void Deactivate() {
        text.gameObject.SetActive(false);
    }

    public ManagerStatus Status { get; set; }
    public void Startup() {
        Deactivate();
        Status = ManagerStatus.Started;
    }
}
