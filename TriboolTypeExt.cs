using System.Runtime.CompilerServices;

namespace Tribools
{
    public static class TriboolTypeExt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TriboolType Not(this TriboolType type)
        {
            return type.GetVal(TriboolType.Indefinitely, TriboolType.False, TriboolType.True);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TriboolType Up(this TriboolType type)
        {
            return type.IsFalse() ? TriboolType.Indefinitely : TriboolType.True;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TriboolType Down(this TriboolType tribool)
        {
            return tribool.IsTrue() ? TriboolType.Indefinitely : TriboolType.False;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToStr(this TriboolType type)
        {
            return type.GetVal("Indefinitely", "True", "False");
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToStrNumber(this TriboolType type)
        {
            return type.GetVal("0", "+1", "-1");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool? ToNullableBool(this TriboolType type)
        {
            return type.GetVal<bool?>(null, true, false);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int HashCode(this TriboolType type)
        {
            return type.GetVal(1, 2, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTrue(this TriboolType tribool)
        {
            return tribool == TriboolType.True;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFalse(this TriboolType tribool)
        {
            return tribool == TriboolType.False;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIndefinitely(this TriboolType tribool)
        {
            return tribool == TriboolType.Indefinitely;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetVal<T>(this TriboolType type, T indefinitely, T trueVal, T falseVal)
        {
            switch (type)
            {
                case TriboolType.Indefinitely: return indefinitely;
                case TriboolType.True:         return trueVal;
                case TriboolType.False:        return falseVal;
                default:                       return indefinitely;
            }
        }
    }
}