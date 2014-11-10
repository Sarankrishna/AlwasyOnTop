using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zambezi.DesktopApp.AlwaysOnTop.Classes
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left, Top, Right, Bottom;
        public RECT(int left, int top, int right, int bottom)
        {
            Left = left; Top = top; Right = right; Bottom = bottom;
        }
        public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }
        public int X { get { return Left; } set { Right -= (Left - value); Left = value; } }
        public int Y { get { return Top; } set { Bottom -= (Top - value); Top = value; } }
        public int Height { get { return Bottom - Top; } set { Bottom = value + Top; } }
        public int Width { get { return Right - Left; } set { Right = value + Left; } }
        public static implicit operator System.Drawing.Rectangle(RECT r)
        {
            return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
        }
        public static implicit operator RECT(System.Drawing.Rectangle r) { return new RECT(r); }
    }
}
