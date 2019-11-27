﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Figures
{
    public sealed class Pawn : Figure
    {
        public Pawn(FigureColor Color) : base(Color)
        {

        }
        private bool _firstMove = true;
        public override MoveState CheckMove(SFigurePosition newPos, SFigurePosition currPos, ref Figure[,] deskGrid)
        {
            if (newPos.Equals(currPos))
            {
                return MoveState.Cannot;
            }

            int idx = -1;
            if (Color == FigureColor.Black)
            {
                idx = idx * -1;
            }
            Figure fig = deskGrid[newPos.X, newPos.Y];

            if (newPos.X == currPos.X + idx)
            {
                if (newPos.Y == currPos.Y + 1 || newPos.Y == currPos.Y - 1)
                {
                    if (fig != null)
                    {
                        return MoveState.Fight;
                    }
                }
                if (newPos.Y == currPos.Y)
                {
                    if (fig == null)
                    {
                        return MoveState.Can;
                    }
                }
            }
            if (newPos.X == currPos.X + idx + idx && newPos.Y == currPos.Y && _firstMove)
            {
                if (fig == null)
                {
                    Figure fig1 = deskGrid[newPos.X + idx, newPos.Y];
                    if (fig == null && fig1 == null)
                    {
                        return MoveState.Can;
                    }
                }
            }
            return MoveState.Cannot;
        }

        public override byte[] GetImage()
        {
            if (Color == FigureColor.White)

                return ResourceImages.PawnWhite;
            else
                return ResourceImages.PawnBlack;
        }
    }
}
