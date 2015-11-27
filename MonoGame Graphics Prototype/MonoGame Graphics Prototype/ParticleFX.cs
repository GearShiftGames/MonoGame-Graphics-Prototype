using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MonoGame_Graphics_Prototype {
    public class ParticleFX {

        List<Particle> particles;

        public ParticleFX() {
            particles = new List<Particle>();
        }

        public void startDirtTrail(float inX, float inY) {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++) {
                particles.Add(new Particle(500.0f, rnd.Next(500, 525), rnd.Next(1000, 2500),
                    rnd.Next(160, 200), rnd.Next(10, 100)));
            }
        }

        public void update(double inTime) {
            for (int i = 0; i < particles.Count; i++) {
                if (particles[i].getLife() > 0) {
                    particles[i].update(inTime);
                } else {
                    particles.RemoveAt(i);
                }
            }
        }

        public List<Particle> getParticles() {
            return particles;
        }

    }
}
