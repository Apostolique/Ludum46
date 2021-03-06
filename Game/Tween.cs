using System;
using Microsoft.Xna.Framework;

namespace GameProject {
    public class Tween {
        public Tween(float duration, float start, float target, Func<float, float> easing, bool repeat = false) {
            Duration = duration;
            Start = start;
            Target = target;
            Easing = easing;
            Repeat = repeat;
        }

        public bool Repeat {
            get;
            set;
        }
        public float Duration {
            get;
            set;
        }
        public float CurrentTime {
            get;
            set;
        }
        public float Value => MathHelper.Lerp(Start, Target, Easing(_percent));
        public float Start {
            get;
            set;
        }
        public float Target {
            get;
            set;
        }

        public Func<float, float> Easing {
            get;
            set;
        }

        /// <returns>true when animation is done.</returns>
        public bool Update(GameTime gameTime) {
            CurrentTime += gameTime.ElapsedGameTime.Milliseconds;

            if (CurrentTime > Duration) {
                if (Repeat) {
                    swap();
                } else {
                    return true;
                }
            }
            return false;
        }

        private void swap() {
            var temp = Start;
            Start = Target;
            Target = temp;
            CurrentTime = 0;
        }

        private float _percent => CurrentTime / Duration;
    }
}