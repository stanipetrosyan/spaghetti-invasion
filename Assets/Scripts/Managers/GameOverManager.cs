using System.Collections.Generic;
using Dialogues;
using Domain;
using Port;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers{
    public class GameOverManager : MonoBehaviour, IManager{
        [SerializeField] private DialogueCharacter player;
        [SerializeField] private DialogueCharacter guard;

        private bool gameOver = false;

        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        private void Update() {
            if (gameOver && !GameManagers.Dialogue.IsActiveDialogue()) {
                SceneManager.LoadScene("GameOver");
            }
        }

        public void GameOver(Reason reason) {
            if (gameOver) return;

            GameManagers.Audio.StopAll();
            GameManagers.Audio.PlayDeath();
            GameManagers.Input.SetCanMove(false);
            PlayerPrefs.SetString("GameOverReason", GetReason(reason));
            Dialogue dialogue = GetDialogue(reason);
            GameManagers.Dialogue.StartDialogue(dialogue);
            gameOver = true;
        }

        private static string GetReason(Reason reason) {
            return reason switch {
                Reason.Light => "Camouflage is not for the faint of heart… The longer you look like them, the more you become one of them.",
                Reason.Guard => "Don’t let them see you without your disguise on!",
                _ => "ERR"
            };
        }

        private Dialogue GetDialogue(Reason reason) {
            var line = reason switch {
                Reason.Light => new DialogueLine(player, "Anxiety overwhelms you. You freeze in shock and will not move."),
                Reason.Guard => new DialogueLine(guard, "You have been found! This time, they’ll make sure to dismiss you properly…"),
                _ => new DialogueLine(player, "getDialog(reason)")
            };

            var dialogue = new Dialogue {
                lines = new List<DialogueLine> { line }
            };
            return dialogue;
        }
    }
}