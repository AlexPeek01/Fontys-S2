using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Managers
{
    public class SorterManager
    {
        public List<Color> SortList(List<Color> oldList)
        {
            bool madeEdit = false;
            for (int j = 0; j < oldList.Count; j++)
            {
                if (j < oldList.Count - 1)
                {
                    if (oldList[j] == Color.White)
                    {
                        if (j < oldList.Count)
                        {
                            oldList[j] = oldList[j + 1];
                            oldList[j + 1] = Color.White;
                            madeEdit = true;
                        }
                    }
                    else if (oldList[j] == Color.Red)
                    {
                        if (j > 0)
                        {
                            oldList[j] = oldList[j - 1];
                            oldList[j - 1] = Color.Red;
                            madeEdit = true;
                        }
                    }
                }
                if (!madeEdit && j != 0 && j != oldList.Count)
                    break;
            }
            return oldList;
        }
    }
}
