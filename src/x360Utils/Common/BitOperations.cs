﻿namespace x360Utils.Common {
    public static class BitOperations {
        public static ulong Swap(ulong x) { return x << 56 | x << 40 | x << 24 | x << 8 | x >> 8 | x >> 24 | x >> 40 | x >> 56; }

        public static uint Swap(uint x) { return x << 24 | x << 8 | x >> 8 | x >> 24; }

        public static ushort Swap(ushort x) { return (ushort) (x << 8 | x >> 8); }

        public static uint CountSetBits(ulong n) {
            uint c;
            for(c = 0; n > 0; c++)
                n &= n - 1;
            return c;
        }

        public static bool DataIsZero(ref byte[] data, int offset = 0, int length = -1) {
            length = length <= 0 ? data.Length - offset : offset + length;
            for(; offset < length; offset++) {
                if(data[offset] != 0x00)
                    return false;
            }
            return true;
        }

        public static int CountByteInstances(ref byte[] data, byte instance) {
            var count = 0;
            foreach(var b in data) {
                if(b == instance)
                    count++;
            }
            return count;
        }

        public static int CountByteInstances(ref byte[] data, byte instance, int offset = 0, int length = -1) {
            var count = 0;
            length = length <= 0 ? data.Length - offset : offset + length;
            for(; offset < length; offset++) {
                if(data[offset] == instance)
                    count++;
            }
            return count;
        }

        public static bool CompareByteArrays(ref byte[] a1, ref byte[] a2, bool checkmax = true) {
            if(a1 == a2)
                return true;
            if(a1 == null || a2 == null)
                return false;
            if(checkmax && a1.Length != a2.Length)
                return false;
            if(!checkmax) {
                Debug.SendDebug("checkmax = false");
                if(a1.Length < a2.Length) {
                    for(var index = 0; index < a1.Length; index++) {
                        if(a1[index] != a2[index]) {
                            Debug.SendDebug("a1[{0}] (0x{1:X2}) != a2[{0}] (0x{2:X})!", index, a1[index], a2[index]);
                            return false;
                        }
                    }
                }
                else {
                    for(var index = 0; index < a2.Length; index++) {
                        if(a1[index] != a2[index]) {
                            Debug.SendDebug("a1[{0}] (0x{1:X2}) != a2[{0}] (0x{2:X})!", index, a1[index], a2[index]);
                            return false;
                        }
                    }
                }
            }
            else {
                Debug.SendDebug("checkmax = true");
                for(var index = 0; index < a1.Length; index++) {
                    if(a1[index] != a2[index]) {
                        Debug.SendDebug("a1[{0}] (0x{1:X2}) != a2[{0}] (0x{2:X})!", index, a1[index], a2[index]);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}