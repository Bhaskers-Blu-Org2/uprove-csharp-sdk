﻿//*********************************************************
//
// This file was imported from the C# Bouncy Castle project. Original license header is retained:
//
//
// License
// Copyright (c) 2000-2014 The Legion of the Bouncy Castle Inc. (http://www.bouncycastle.org)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
//
//*********************************************************

namespace BouncyCastle
{
    public class ReferenceMultiplier
        : AbstractECMultiplier
    {
        /**
         * Simple shift-and-add multiplication. Serves as reference implementation
         * to verify (possibly faster) implementations in
         * {@link org.bouncycastle.math.ec.ECPoint ECPoint}.
         * 
         * @param p The point to multiply.
         * @param k The factor by which to multiply.
         * @return The result of the point multiplication <code>k * p</code>.
         */
        protected override ECPoint MultiplyPositive(ECPoint p, BigInteger k)
        {
            ECPoint q = p.Curve.Infinity;
            int t = k.BitLength;
            if (t > 0)
            {
                if (k.TestBit(0))
                {
                    q = p;
                }
                for (int i = 1; i < t; i++)
                {
                    p = p.Twice();
                    if (k.TestBit(i))
                    {
                        q = q.Add(p);
                    }
                }
            }
            return q;
        }
    }
}
