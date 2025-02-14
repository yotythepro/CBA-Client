using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    /// <summary>
    /// Class representing every player in the game.
    /// </summary>
    internal class Player
    {
        public int id;
        public double xPos;
        public double xSpeed = 0;
        public double yPos;
        public double ySpeed = 0;
        public double yAcc = 0;
        public PlayerState state;
        const float jumpSpeed = 20f;
        const float gravity = 50f;
        public static int count = 0;
        public static List<Player> allPlayers = new List<Player>();
        public bool isAttacking = false;
        public bool recovery = false;
        public bool facingRight;
        public bool isAlive = true;
        private double timeSinceAttack = 0;
        public string name;
        public TcpClient cl;
        public bool IsInRoom = false;
        public Room room;

        public Player(string name, TcpClient client)
        {
            this.name = name;
            cl = client;
        }

        /// <summary>
        /// Creates a new instance of player using (<paramref name="xPos"/>, <paramref name="yPos"/>) as its position.
        /// </summary>
        /// <param name="xPos">Player's initial X position.</param>
        /// <param name="yPos">Player's initial Y position.</param>
        /// <param name="facingRight">Whether the player is facing to the right.</param>
        public Player(float xPos, double yPos, bool facingRight)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.facingRight = facingRight;
            id = count++;
            allPlayers.Add(this);
            StartRunning();
        }

        public void SendAlert(Alert alert)
        {
            Program.SendMessage("A" + JsonSerializer.Serialize(alert), cl);
        }

        /// <summary>
        /// Start updating the player's state.
        /// </summary>
        private void StartRunning()
        {
            Task.Run(() => Run());
        }

        /// <summary>
        /// Continuosly update the player
        /// </summary>
        private void Run()
        {
            TimeSpan deltaTime;
            DateTime oldTime = DateTime.Now;
            while (isAlive)
            {
                deltaTime = DateTime.Now - oldTime;
                oldTime = DateTime.Now;
                Update(deltaTime.TotalSeconds);
            }
            state = PlayerState.Dead;
        }

        /// <summary>
        /// Update the player's state once.
        /// </summary>
        /// <param name="dt">Time passed since last update.</param>
        private void Update(double dt)
        {
            timeSinceAttack += dt;
            if(recovery && timeSinceAttack > 0.7) recovery = false;
            xPos += xSpeed * dt;
            if(yPos <= 0)
            {
                yPos = 0;
                ySpeed = Math.Max(ySpeed, 0);
                yAcc = 0;
                if(facingRight)
                {
                    if (isAttacking)
                        state = PlayerState.AttackRight;
                    else if (recovery)
                        state = PlayerState.RecoveryRight;
                    else
                        state = PlayerState.FaceRight;
                } 
                else
                {
                    if (isAttacking)
                        state = PlayerState.AttackLeft;
                    else if (recovery)
                        state = PlayerState.RecoveryLeft;
                    else
                        state = PlayerState.FaceLeft;
                }
            }
            else
            {
                yAcc = -1 * gravity;
                if (facingRight)
                {
                    if (isAttacking)
                        state = PlayerState.MidairAttackRight;
                    else if (recovery)
                        state = PlayerState.MidairRecoveryRight;
                    else
                        state = PlayerState.MidairFaceRight;
                }
                else
                {
                    if (isAttacking)
                        state = PlayerState.MidairAttackLeft;
                    else if (recovery)
                        state = PlayerState.MidairRecoveryLeft;
                    else
                        state = PlayerState.MidairFaceLeft;
                }
            }
            ySpeed += yAcc * dt;
            yPos += ySpeed * dt;
        }

        /// <summary>
        /// Make the player start moving to the right.
        /// </summary>
        public void TurnRight()
        {
            xSpeed = 10;
            facingRight = true;
        }

        /// <summary>
        /// Make the player start moving to the left.
        /// </summary>
        public void TurnLeft()
        {
            xSpeed = -10;
            facingRight = false;
        }

        /// <summary>
        /// Make the player jump.
        /// </summary>
        public void Jump()
        {
            if (yPos <= 0 && !isAttacking)
                ySpeed = jumpSpeed;
        }

        /// <summary>
        /// Make the player attack.
        /// </summary>
        public void Attack()
        {
            if (timeSinceAttack < 0.7)
                return;
            timeSinceAttack = 0;
            isAttacking = true;
            if (yPos <= 0)
            {
                if (facingRight) //player facing right
                {
                    new Hitbox(this, new System.Drawing.PointF(1, -0.5f), 0.2, 0.25);
                }
                else
                {
                    new Hitbox(this, new System.Drawing.PointF(0, -0.5f), 0.2, 0.25);
                }
            }
            else
            {
                new Hitbox(this, new System.Drawing.PointF(0.5f, -0.5f), 0.3, 0.7);
            }
        }

        /// <summary>
        /// Convert the player's state to a string.
        /// </summary>
        /// <returns>A string reperesenting the player's position and current state.</returns>
        public override string ToString()
        {
            return $"{{{xPos}, {yPos}, {(int)state}}}";
        }

        /// <summary>
        /// Kill the player.
        /// </summary>
        public void Kill()
        {
            isAlive = false;
        }
    }
}
