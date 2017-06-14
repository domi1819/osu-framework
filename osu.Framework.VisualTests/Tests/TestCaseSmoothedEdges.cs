﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Framework.VisualTests.Tests
{
    internal class TestCaseSmoothedEdges : GridTestCase
    {
        public TestCaseSmoothedEdges() : base(2, 2)
        {
        }

        public override string Description => @"Boxes with automatically smoothed edges (no anti-aliasing).";

        private readonly Box[] boxes = new Box[4];

        public override void Reset()
        {
            base.Reset();

            Vector2[] smoothnesses =
            {
                new Vector2(0, 0),
                new Vector2(0, 2),
                new Vector2(1, 1),
                new Vector2(2, 2),
            };

            for (int i = 0; i < Rows * Cols; ++i)
            {
                Cell(i).Add(new Drawable[]
                {
                    new SpriteText
                    {
                        Text = $"{nameof(Sprite.EdgeSmoothness)}={smoothnesses[i]}",
                        TextSize = 20,
                    },
                    boxes[i] = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.White,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Size = new Vector2(0.5f),
                        EdgeSmoothness = smoothnesses[i],
                    },
                });
            }
        }

        protected override void Update()
        {
            base.Update();

            foreach (Box box in boxes)
                box.Rotation += 0.01f;
        }
    }
}
