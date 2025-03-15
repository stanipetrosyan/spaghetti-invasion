using System;
using System.Collections.Generic;

namespace Dialogues {
    [Serializable]
    public class Dialogue{
        public List<DialogueLine> lines = new();
    }
}