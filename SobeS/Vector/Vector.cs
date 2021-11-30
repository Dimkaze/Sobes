using System;

namespace SobeS
{
     class Vector
     {
         private int x;
         private int z;
         private int y;
         public Vector(int x, int z, int y)
         {
             this.x = x;
             this.z = z;
             this.y = y;    
         }
         public Vector() { }
         public int X { get => x; set { if (value > 0) X = value; } }
         public int Y { get => y; set { if (value > 0) Y = value; } }
         public int Z { get => z; set { if (value > 0) Z = value; } }
         
         public static Vector operator +(Vector a1,Vector a2)
         {
             return new Vector(a1.X + a2.X, a1.Z + a2.Z, a1.Y + a2.Y);
         }

         public void Print()
         {
             Console.WriteLine($"X = {X} Y = {Y} Z = {Z}");
         }
     }  
}