//  gSeer, a C# Artificial Neural Network Library
//  Copyright (C) 2018  Garfunkel Vila
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 3 of the License, or any later version.
//  
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library. If not,
//  see<https://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gSeer.Parsers {
    public class SeerParser {
        /// <summary>
        /// Float because neuron only reads float
        /// </summary>
        /// <param name="b">Byte to convert</param>
        /// <returns>Float array of binary</returns>
        public float[] ConvertByteToBin (byte b) {
            // I dont know if there is a simplier way for this
            // It maybe reverse, I dont know yet
            float[] rBuffer = new float[8];
            char[] ch = Convert.ToString(b, 2).ToCharArray();
            for (int i = 0; i < ch.Length; i++) {
                rBuffer[i] = (float)ch[i];
            }
            return rBuffer;
        }
        public byte ConvertBinToByte (float[] b) {
            // I dont know if there is a simplier way for this
            // It maybe reverse, I dont know yet
            // https://www.csharpstar.com/csharp-program-to-convert-binary-string-to-integer/
            string s = "";
            foreach (float item in b) {
                byte temp = (byte) item;  // Truncate
                s += temp;
            }
            byte OnOff = 0;
            byte result = 0;
            //Loop through each character in the passed string
            for (int i = 0; i < s.Length; i++) {
                try {
                    //Parse each char of the passed string
                    OnOff = byte.Parse(s[i].ToString());

                    //If the char is a 1, add 2^(the position it's in) to the result
                    if (OnOff == 1)
                        result += (byte) Math.Pow(2, s.Length - 1 - i);

                    else if (OnOff > 1)
                        throw new Exception("Invalid input");
                }
                catch {
                    throw new Exception("Invalid input");
                }
            }
            return (byte) result;
        }
    }
}
