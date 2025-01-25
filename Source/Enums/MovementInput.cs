using System;

[Flags]
public enum MovementInput
{
    INPUT_NONE  = 0b0000_0000,
    INPUT_UP    = 0b0000_0001,
    INPUT_RIGHT = 0b0000_0010,
    INPUT_DOWN  = 0b0000_0100,
    INPUT_LEFT  = 0b0000_1000,
    INPUT_JUMP  = 0b0001_0000,
    INPUT_MORPH = 0b0010_0000,
    INPUT_ALL   = 0b1111_1111
}