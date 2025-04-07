using System;
using System.Collections.Generic;
using Dialogues;
using Port;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Managers {
    public class GameOverManager: MonoBehaviour, IManager{

        [SerializeField] private DialogueCharacter player;
        [FormerlySerializedAs("opponent")] [SerializeField] private DialogueCharacter guard;
        
        private DialogueTrigger dialogueTrigger;
        private bool gameOver = false;

        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
            dialogueTrigger = new DialogueTrigger();
        }

        private void Update() {
            if (gameOver && !GameManagers.Dialogue.IsActiveDialogue()) {
                SceneManager.LoadScene("GameOver");
            }
        }

        public void GameOver(Reason reason) {
            PlayerPrefs.SetString("GameOverReason", getReason(reason));

            Dialogue dialogue = getDialogue(reason);
            dialogueTrigger.dialogue = dialogue;
            dialogueTrigger.StartDialogue();
            gameOver = true;
        }

        private string getReason(Reason reason) {
            switch (reason) {
                case Reason.Light:
                    return "You became one of them";
                case Reason.Guard:
                    return "They caught you and ate you!";
                default:
                    return "ERR";
            }
        }

        private Dialogue getDialogue(Reason reason) {

            DialogueLine line = new DialogueLine(player, "getDialog(reason)");
            
            switch (reason) {
                case Reason.Light:
                    line = new DialogueLine(player, "DIALOGO MORTE PER LUCE");
                    break;
                case Reason.Guard:
                    line = new DialogueLine(guard, "DIALOGO MORTE PER GUARDIA");
                    break;
                default:
                    line = new DialogueLine(player, "getDialog(reason)");
                    break;
            }
            
            Dialogue dialogue = new Dialogue();
            dialogue.lines = new List<DialogueLine>{line};
            return dialogue;
        }
    }
}

public enum Reason{
    Light,
    Guard
}