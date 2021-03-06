﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;

namespace osu.Framework.VisualTests.Tests
{
    internal class TestCaseEffects : TestCase
    {
        public override string Description => "Tests classes implement the IEffect interface.";

        public override void Reset()
        {
            base.Reset();

            var effect = new EdgeEffect
            {
                CornerRadius = 3f,
                Parameters = new EdgeEffectParameters
                {
                    Colour = Color4.LightBlue,
                    Hollow = true,
                    Radius = 5f,
                    Type = EdgeEffectType.Glow
                }
            };
            Add(new FillFlowContainer
            {
                Position = new Vector2(10f, 10f),
                Spacing = new Vector2(25f, 25f),
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Text = "Blur Test",
                        TextSize = 32f
                    }.WithEffect(new BlurEffect
                    {
                        Sigma = new Vector2(2f, 0f),
                        Strength = 2f,
                        BlurRotation = 45f,
                    }),
                    new SpriteText
                    {
                        Text = "EdgeEffect Test",
                        TextSize = 32f
                    }.WithEffect(new EdgeEffect
                    {
                        CornerRadius = 3f,
                        Parameters = new EdgeEffectParameters
                        {
                            Colour = Color4.Yellow,
                            Hollow = true,
                            Radius = 5f,
                            Type = EdgeEffectType.Shadow
                        }
                    }),
                    new SpriteText
                    {
                        Text = "Repeated usage of same effect test",
                        TextSize = 32f
                    }.WithEffect(effect),
                    new SpriteText
                    {
                        Text = "Repeated usage of same effect test",
                        TextSize = 32f
                    }.WithEffect(effect),
                    new SpriteText
                    {
                        Text = "Repeated usage of same effect test",
                        TextSize = 32f
                    }.WithEffect(effect),
                    new SpriteText
                    {
                        Text = "Multiple effects Test",
                        TextSize = 32f
                    }.WithEffect(new BlurEffect
                    {
                        Sigma = new Vector2(2f, 2f),
                        Strength = 2f
                    }).WithEffect(new EdgeEffect
                    {
                        CornerRadius = 3f,
                        Parameters = new EdgeEffectParameters
                        {
                            Colour = Color4.Yellow,
                            Hollow = true,
                            Radius = 5f,
                            Type = EdgeEffectType.Shadow
                        }
                    }),
                }
            });
        }
    }
}
