using System.Collections.Generic;
using StateMachine.Interfaces;

namespace StateMachine.BitMaskArray
{
    public class MaskArray
    {
        private readonly int[][] _preComputedIndexes;
        private uint _bitMask;

        public MaskArray(IIndexed[] items)
        {
            _bitMask = 0;
            var length = items.Length;

            _preComputedIndexes = new int[1 << length][];

            for (uint i = 0; i < length; i++) items[i].SetIndex(1u << (int)i);

            CalculateIndexes(length);
        }

        private void CalculateIndexes(int length)
        {
            for (uint i = 0; i < _preComputedIndexes.Length; i++)
            {
                var indices = new List<int>();
                for (var bit = 0; bit < length; bit++)
                    if ((i & (1 << bit)) != 0)
                        indices.Add(bit);
                _preComputedIndexes[i] = indices.ToArray();
            }
            // example out
            // _preComputedIndexes = new int[][]
            // {
            //     new int[] {},        // 0
            //     new int[] {0},      // 1
            //     new int[] {1},      // 2
            //     new int[] {0, 1},   // 3
            // }; 
        }

        public bool Contains(uint index)
        {
            var compare = index & _bitMask;
            return compare == index;
        }

        public void Add(uint index)
        {
            _bitMask |= index;
        }

        public void Remove(uint index)
        {
            _bitMask &= ~index;
        }

        public int[] GetIndexesFromMask() //return indexes has ACTIVE
        {
            return _preComputedIndexes[_bitMask];
        }

        public void ClearMask()
        {
            _bitMask = 0;
        }
    }
}