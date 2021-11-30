using System;
using System.Numerics;

namespace SobeS
{
    class TripleVector : Vector
    {
        private Vector[] vecs;
        public TripleVector(Vector[] vecs) { this.vecs = vecs; }
        public TripleVector() { } 
        public Vector[] Vecs { get => vecs;}

        public bool IsOrtagonal(Vector v1,Vector v2)
        {
            if ((v1.X == v2.X && v1.Y == v2.Y) || (v1.X == v2.X && v1.Z == v2.Z))
                return true;
            if (v1.Z == v2.Z && v1.Y == v2.Y)
                return true;
            return false;
        }
        public Vector this[int index]  { get => vecs[index]; set { vecs[index] = value; } }
        public bool HaveTwo(Vector a1)
        {
            if (a1.X == 2 || a1.Y == 2 || a1.Z == 2)
                return true;
            return false;
        }
        public void Porazriad(Vector a1, Vector a2)
        {
            Console.WriteLine($"x = {a1.X & a2.X}, y = {a1.Z + a2.Z}, z = {a1.Y + a2.Y}");
        }
        ~TripleVector() { }
    }
}