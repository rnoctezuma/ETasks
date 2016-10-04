using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VectorGraphicsEditor.Figures
{
    public interface IFigure  //c площадью / без площади?????
    {
        double GetArea { get; }
        double GetLength { get; }
        string Draw();
    }
}
