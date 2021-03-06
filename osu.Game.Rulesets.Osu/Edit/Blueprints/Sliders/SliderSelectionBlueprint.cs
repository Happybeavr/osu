﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Osu.Edit.Blueprints.Sliders.Components;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.Objects.Drawables;
using osuTK;

namespace osu.Game.Rulesets.Osu.Edit.Blueprints.Sliders
{
    public class SliderSelectionBlueprint : OsuSelectionBlueprint
    {
        private readonly SliderCircleSelectionBlueprint headBlueprint;

        public SliderSelectionBlueprint(DrawableSlider slider)
            : base(slider)
        {
            var sliderObject = (Slider)slider.HitObject;

            InternalChildren = new Drawable[]
            {
                new SliderBodyPiece(sliderObject),
                headBlueprint = new SliderCircleSelectionBlueprint(slider.HeadCircle, sliderObject, SliderPosition.Start),
                new SliderCircleSelectionBlueprint(slider.TailCircle, sliderObject, SliderPosition.End),
                new PathControlPointVisualiser(sliderObject),
            };
        }

        public override Vector2 SelectionPoint => headBlueprint.SelectionPoint;
    }
}
