using System;
using Assets.Data;

namespace Assets.Vision
{
    public class VisionField
    {
        protected float leftBorderModifier = 1.0f;
        protected float rightBorderModifier = 1.0f;
        protected float topBorderModifier = 1.0f;
        protected float bottomBorderModifier = 1.0f;
        protected float radiusModifier = 1.0f;

        public VisionField(IVisionData visionData)
        {
            VisionData = visionData ?? throw new ArgumentNullException(nameof(visionData));
        }

        public IVisionData VisionData {get; protected set; }

        public float LeftVisionBorderModifier
        {
            get => leftBorderModifier < 0.0f ? 0.0f : leftBorderModifier;
            set => leftBorderModifier = value;
        }
        public float RightVisionBorderModifier
        {
            get => rightBorderModifier < 0.0f ? 0.0f : rightBorderModifier;
            set => rightBorderModifier = value;
        }
        public float TopVisionBorderModifier
        {
            get => topBorderModifier < 0.0f ? 0.0f : topBorderModifier;
            set => topBorderModifier = value;
        }
        public float BottomVisionBorderModifier
        {
            get => bottomBorderModifier < 0.0f ? 0.0f : bottomBorderModifier;
            set => bottomBorderModifier = value;
        }
        public float RadiusModifier
        {
            get => radiusModifier < 0.0f ? 0.0f : radiusModifier;
            set => radiusModifier = value;
        }
        public float LeftVisionBorder
        {
            get
            {
                float angle = VisionData.MaximumLeftAngle * LeftVisionBorderModifier;
                return angle > 180.0f ? 180.0f : angle;
            }
        }
        public float RightVisionBorder
        {
            get
            {
                float angle = VisionData.MaximumRightAngle * RightVisionBorderModifier;
                return angle > 180.0f ? 180.0f : angle;
            }
        }
        public float TopVisionBorder
        {
            get
            {
                float angle = VisionData.MaximumTopAngle * TopVisionBorderModifier;
                return angle > 180.0f ? 180.0f : angle;
            }
        }
        public float BottomVisionBorder
        {
            get
            {
                float angle = VisionData.MaximumBottomAngle * BottomVisionBorderModifier;
                return angle > 180.0f ? 180.0f : angle;
            }
        }
        public float HorizontalViewAngle
        {
            get => LeftVisionBorder + RightVisionBorder;
        }
        public float VerticalViewAngle
        {
            get => BottomVisionBorder + TopVisionBorder;
        }
        public float Radius => VisionData.Radius * RadiusModifier;



        public bool WithinHorizontalRange(float angle)
        {
            return angle < LeftVisionBorder || angle < RightVisionBorder;
        }

        public bool WithinVerticalRange(float angle)
        {
            return angle < BottomVisionBorder || angle < TopVisionBorder;
        }

        public bool WithinVisionRange(float horizontalAngle, float verticalAngle)
        {
            return WithinHorizontalRange(horizontalAngle) && WithinVerticalRange(verticalAngle);
        }
    }
}
