using AmeisenMovement.Interfaces;
using AmeisenMovement.Structs;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AmeisenMovement.Formations
{
    /// <summary>
    /// Random based chaotic formation
    /// </summary>
    public class DefaultFormation : IFormation
    {
        private readonly List<Vector> randomOffsets = new List<Vector>();
        private Random rnd = new Random();

        public Vector4 GetPosition(Vector4 inputPosition, double distance, int memberId, int memberCount)
        {
            Vector4 position = new Vector4(inputPosition);

            while (randomOffsets.Count <= memberId)
            {
                randomOffsets.Add(new Vector(rnd.Next(-4, 4), rnd.Next(-4, 4)));
            }

            position.X += Math.Cos(inputPosition.R + GetAngleOffset(memberId, memberCount)) * (distance) + randomOffsets[memberId].X;
            position.Y += Math.Sin(inputPosition.R + GetAngleOffset(memberId, memberCount)) * (distance) + randomOffsets[memberId].Y;

            return position;
        }

        private double GetAngleOffset(int memberId, int memberCount)
        {
            return (memberId / (double)memberCount);
        }
    }
}