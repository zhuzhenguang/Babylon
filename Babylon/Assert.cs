using System;

namespace Babylon
{
    public class Assert
    {
        public static void NotNull(object obj, string message = "")
        {
            if (obj == null)
            {
                throw new Exception(message);
            }
        }
    }
}