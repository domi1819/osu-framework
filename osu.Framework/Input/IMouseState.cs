﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK;
using OpenTK.Input;

namespace osu.Framework.Input
{
    public interface IMouseState
    {
        IMouseState NativeState { get; }

        IMouseState LastState { get; set; }

        Vector2 Delta { get; }
        Vector2 Position { get; }

        Vector2 LastPosition { get; }

        Vector2? PositionMouseDown { get; set; }

        bool HasMainButtonPressed { get; }

        bool IsPressed(MouseButton button);

        void SetPressed(MouseButton button, bool pressed);

        int Wheel { get; }

        int WheelDelta { get; }

        IMouseState Clone();
    }
}
