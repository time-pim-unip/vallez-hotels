using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DateTimeExtensao
    {

        public static List<DateTime> RetornarPeriodo(this DateTime inicio, DateTime fim)
        {
            List<DateTime> datas = new List<DateTime>();
            int diferencaDias = int.Parse(Math.Ceiling(fim.Subtract(inicio).TotalDays).ToString());
            for (int i = 0; i <= diferencaDias; i++)
            {
                datas.Add(inicio.AddDays(i));
            }

            return datas;
        }

    }
}
