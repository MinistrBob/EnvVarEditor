using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvVarEditor
{
    /// <summary>
    /// Статический класс Data Container (DC) для передачи данных между формами, доступен из любой формы
    /// </summary>
    static class DC
    {
        public static bool IsSendMessages { get; set; }


    }
}
