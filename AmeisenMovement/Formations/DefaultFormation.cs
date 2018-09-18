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
        private Random rnd = new Random();
        private readonly List<Vector> randomOffsets = new List<Vector>();

        public Vector4 GetPosition(Vector4 inputPosition, double distance, int memberId, int memberCount)
        {
            Vector4 position = new Vector4(inputPosition);

            if (randomOffsets.Count <= memberId)
            {
                randomOffsets.Add(new Vector(rnd.Next(-40, 40), rnd.Next(-40, 40)));
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
