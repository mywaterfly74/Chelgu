using System;
using System.Linq;

namespace Pyatna
{
    public interface IPlayable
    {
        void Randomize();
        bool IsFinished();
        void Shift(int value);
        int GetLength();
        int this[int x, int y]
        {
            get;
        }
    }
}