using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ButtonTypes { NEXT, BACK, CLOSE }
public class ButtonClickEvent : EventArgs {
    public ButtonTypes ButtonType { get; set; }

    public ButtonClickEvent(ButtonTypes ButtonType) {
        this.ButtonType = ButtonType;
    }
}
