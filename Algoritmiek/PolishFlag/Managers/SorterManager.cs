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
            for (int i = 0; i < oldList.Count; i++)
            {
                bool madeEdit = false;
                for (int j = 0; j < oldList.Count; j++)
                {
                    if (j < oldList.Count - 1)
                    {
                        if (oldList[j] == Color.White && oldList[j + 1] == Color.Red)
                        {
                            oldList[j] = Color.Red;
                            oldList[j + 1] = Color.White;
                            madeEdit = true;
                        }
                    }
                }
                if (!madeEdit)
                    break;
            }
            return oldList;
        }
    }
}
