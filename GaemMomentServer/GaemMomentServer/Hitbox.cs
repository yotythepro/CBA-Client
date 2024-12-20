using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    /// <summary>
    /// Represents an attack's hitbox.
    /// </summary>
    internal class Hitbox
    {
        readonly Player attacker;
        PointF location;
        readonly PointF offset;
        double ttl;
        readonly double radius;

        /// <summary>
        /// Makes a new hitbox.
        /// </summary>
        /// <param name="attacker">Player whose attack created the hitbox.</param>
        /// <param name="offset">Position of the attack relative to the attacking player.</param>
        /// <param name="ttl">How long (in seconds) should the hitbox stay active.</param>
        /// <param name="radius">Radius of the hitbox.</param>
        public Hitbox(Player attacker, PointF offset, double ttl, double radius)
        {
            this.attacker = attacker;
            this.offset = offset;
            location = new PointF((float) attacker.xPos + offset.X, (float) attacker.yPos + offset.Y);
            this.ttl = ttl;
            this.radius = radius;
            Run();
        }

        /// <summary>
        /// Continuosly update the hitbox while it's active.
        /// </summary>
        private void Run()
        {
            TimeSpan deltaTime;
            DateTime oldTime = DateTime.Now;
            while (ttl > 0)
            {
                deltaTime = DateTime.Now - oldTime;
                oldTime = DateTime.Now;
                Update(deltaTime.TotalSeconds);
            }
            attacker.isAttacking = false;
            attacker.recovery = true;
        }

        /// <summary>
        /// Check wether the hitbox is hitting a certain player.
        /// </summary>
        /// <param name="player">The player to check for.</param>
        /// <returns>True if the hitbox colides with the player, otherwise false.</returns>
        private bool HitsPlayer(Player player)
        {
            PointF playerCenter = new PointF((float)(player.xPos + 0.5), (float)(player.yPos - 0.5));
            return ((location.X - playerCenter.X) * (location.X - playerCenter.X) + (location.Y - playerCenter.Y) * (location.Y - playerCenter.Y)) < radius * radius;
        }

        /// <summary>
        /// Update the hitbox's position and time to stay active.
        /// Also kills any player coliding with the hitbox other than the attacker.
        /// </summary>
        /// <param name="dt">Time passed since last update.</param>
        private void Update(double dt)
        {
            ttl -= dt;
            location = new PointF((float)attacker.xPos + offset.X, (float)attacker.yPos + offset.Y);
            foreach (Player pl in Player.allPlayers) {
                if (pl.id == attacker.id) continue;
                if (HitsPlayer(pl)) pl.Kill();
            }
        }
    }
}
