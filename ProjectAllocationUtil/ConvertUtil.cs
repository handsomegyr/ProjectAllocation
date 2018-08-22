using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace ProjectAllocationUtil
{
    public class ConvertUtil
    {
        // Methods
        public static string ToString(object Value, string DefaultValue = "")
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    return DefaultValue;
                }

                return System.Convert.ToString(Value).Trim();
            }
            catch
            {
                return DefaultValue;
            }
        }

        public static bool ToBoolean(object Value, bool DefaultValue = false)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    return DefaultValue;
                }

                return System.Convert.ToBoolean(Value);
            }
            catch
            {
                return DefaultValue;
            }
        }
        public static int[] ToInt(object[] Value, int[] DefaultValue, int MinValue = int.MinValue, int MaxValue = int.MaxValue)
        {
            int[] numArray = new int[Value.Length];
            for (int i = 0; i < Value.Length; i++)
            {
                try
                {
                    if (isNullOrEmpty(Value[i]))
                    {
                        numArray[i] = DefaultValue[i];
                    }

                    int num = System.Convert.ToInt32(Value[i]);
                    if ((num < MinValue) || (num > MaxValue))
                    {
                        numArray[i] = DefaultValue[i];
                    }
                    else
                    {
                        numArray[i] = num;
                    }
                }
                catch
                {
                    numArray[i] = DefaultValue[i];
                }
            }
            return numArray;
        }

        public static int[] ToInt(object[] Value, int DefaultValue = 0, int MinValue = int.MinValue, int MaxValue = int.MaxValue)
        {
            int[] numArray = new int[Value.Length];
            for (int i = 0; i < Value.Length; i++)
            {
                try
                {
                    if (isNullOrEmpty(Value[i]))
                    {
                        numArray[i] = DefaultValue;
                    }

                    int num = System.Convert.ToInt32(Value[i]);
                    if ((num < MinValue) || (num > MaxValue))
                    {
                        numArray[i] = DefaultValue;
                    }
                    else
                    {
                        numArray[i] = num;
                    }
                }
                catch
                {
                    numArray[i] = DefaultValue;
                }
            }
            return numArray;
        }

        public static int ToInt(object Value, int DefaultValue = 0, int MinValue = int.MinValue, int MaxValue = int.MaxValue)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    return DefaultValue;
                }

                int num = System.Convert.ToInt32(Value);
                if ((num < MinValue) || (num > MaxValue))
                {
                    return DefaultValue;
                }
                return num;
            }
            catch
            {
                return DefaultValue;
            }
        }

        public static int ToInt(object Value, out bool IsError, int DefaultValue = 0, int MinValue = int.MinValue, int MaxValue = int.MaxValue)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    IsError = false;
                    return DefaultValue;
                }

                int num = System.Convert.ToInt32(Value);
                if ((num < MinValue) || (num > MaxValue))
                {
                    IsError = true;
                    return DefaultValue;
                }
                IsError = false;
                return num;
            }
            catch
            {
                IsError = true;
                return DefaultValue;
            }
        }

        public static long[] ToLong(object[] Value, long[] DefaultValue, long MinValue = long.MinValue, long MaxValue = long.MaxValue)
        {
            long[] numArray = new long[Value.Length];
            for (int i = 0; i < Value.Length; i++)
            {
                try
                {
                    if (isNullOrEmpty(Value[i]))
                    {
                        numArray[i] = DefaultValue[i];
                    }

                    long num = System.Convert.ToInt64(Value[i]);
                    if ((num < MinValue) || (num > MaxValue))
                    {
                        numArray[i] = DefaultValue[i];
                    }
                    else
                    {
                        numArray[i] = num;
                    }
                }
                catch
                {
                    numArray[i] = DefaultValue[i];
                }
            }
            return numArray;
        }

        public static long[] ToLong(object[] Value, long DefaultValue = 0, long MinValue = long.MinValue, long MaxValue = long.MaxValue)
        {
            long[] numArray = new long[Value.Length];
            for (int i = 0; i < Value.Length; i++)
            {
                try
                {
                    if (isNullOrEmpty(Value[i]))
                    {
                        numArray[i] = DefaultValue;
                    }

                    long num = System.Convert.ToInt64(Value[i]);
                    if ((num < MinValue) || (num > MaxValue))
                    {
                        numArray[i] = DefaultValue;
                    }
                    else
                    {
                        numArray[i] = num;
                    }
                }
                catch
                {
                    numArray[i] = DefaultValue;
                }
            }
            return numArray;
        }

        public static long ToLong(object Value, long DefaultValue = 0, long MinValue = long.MinValue, long MaxValue = long.MaxValue)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    return DefaultValue;
                }
                long num = System.Convert.ToInt64(Value);
                if ((num < MinValue) || (num > MaxValue))
                {
                    return DefaultValue;
                }
                return num;
            }
            catch
            {
                return DefaultValue;
            }
        }

        public static long ToLong(object Value, out bool IsError, long DefaultValue = 0, long MinValue = long.MinValue, long MaxValue = long.MaxValue)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    IsError = false;
                    return DefaultValue;
                }

                long num = System.Convert.ToInt64(Value);
                if ((num < MinValue) || (num > MaxValue))
                {
                    IsError = true;
                    return DefaultValue;
                }
                IsError = false;
                return num;
            }
            catch
            {
                IsError = true;
                return DefaultValue;
            }
        }


        public static double[] ToDouble(object[] Value, double[] DefaultValue, double MinValue = Double.MinValue, double MaxValue = Double.MaxValue)
        {
            double[] numArray = new double[Value.Length];
            for (int i = 0; i < Value.Length; i++)
            {
                try
                {
                    if (isNullOrEmpty(Value))
                    {
                        numArray[i] = DefaultValue[i];
                    }

                    double num = System.Convert.ToDouble(Value[i]);
                    if ((num < MinValue) || (num > MaxValue))
                    {
                        numArray[i] = DefaultValue[i];
                    }
                    else
                    {
                        numArray[i] = num;
                    }
                }
                catch
                {
                    numArray[i] = DefaultValue[i];
                }
            }
            return numArray;
        }

        public static double[] ToDouble(object[] Value, double DefaultValue = 0.0D, double MinValue = Double.MinValue, double MaxValue = Double.MaxValue)
        {
            double[] numArray = new double[Value.Length];
            for (int i = 0; i < Value.Length; i++)
            {
                try
                {
                    if (isNullOrEmpty(Value))
                    {
                        numArray[i] = DefaultValue;
                    }

                    double num = System.Convert.ToDouble(Value[i]);
                    if ((num < MinValue) || (num > MaxValue))
                    {
                        numArray[i] = DefaultValue;
                    }
                    else
                    {
                        numArray[i] = num;
                    }
                }
                catch
                {
                    numArray[i] = DefaultValue;
                }
            }
            return numArray;
        }

        public static double ToDouble(object Value, double DefaultValue = 0.0D, double MinValue = Double.MinValue, double MaxValue = Double.MaxValue)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    return DefaultValue;
                }

                double num = System.Convert.ToDouble(Value);
                if ((num < MinValue) || (num > MaxValue))
                {
                    return DefaultValue;
                }
                return num;
            }
            catch
            {
                return DefaultValue;
            }
        }

        public static double ToDouble(object Value, out bool IsError, double DefaultValue =0.0D, double MinValue = Double.MinValue, double MaxValue = Double.MaxValue)
        {
            try
            {
                if (isNullOrEmpty(Value))
                {
                    IsError = false;
                    return DefaultValue;
                }

                double num = System.Convert.ToDouble(Value);
                if ((num < MinValue) || (num > MaxValue))
                {
                    IsError = true;
                    return DefaultValue;
                }
                IsError = false;
                return num;
            }
            catch
            {
                IsError = true;
                return DefaultValue;
            }
        }

        public static object ZeroToNull(object Value,object DefaultNull)
        {
            if (Value == null) return null;
            if (Value is string)
            {
                string tmp = Value as string;
                if (tmp != null) tmp = tmp.Trim();
                if (string.IsNullOrEmpty(tmp))
                {
                    return DefaultNull;
                }
            }

            if (Value is int || Value is double)
            {
                if ((double)Value == 0.0D)
                {
                    return DefaultNull;
                }
            }

            return Value;
        }

        private static bool isNullOrEmpty(object Value)
        {
            if (Value == null) return true;
            if (Value is DBNull) return true;
            if (Value is string)
            {
                string tmp = Value as string;
                if (tmp != null) tmp = tmp.Trim();
                if (string.IsNullOrEmpty(tmp))
                {
                    return true;
                }
            }
            return false;
        }

    }

}
